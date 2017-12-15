using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SaveGame;
using StateMachine;

namespace AI
{
    enum GuardState { NORMAL, CURIOUS, ALARMED, DISTRACTED};

    public class Guard : AIAgent
    {

        [Header("Agent Navigation")]
        public bool randomPick;
        [SerializeField]
        public List<NavPoint> wayPointList;

        [Space(10)]
        [Header("Agent States Parameters")]
        public GuardStats normalStats;
        public GuardStats curiousStats;
        public GuardStats alarmedStats;
        public GuardStats distractedStats;

        [Space(10)]
        [Header("Agent Perception Component")]
        [HideInInspector]public GameObject guardAllert;

        // Player
        [HideInInspector] public CharacterInterface[] characterInterfaces;

        // State
        GuardState m_State = GuardState.NORMAL;
        GuardStats stats;

        //Patrols
        [HideInInspector] public int nextWayPoint = 0;
        [HideInInspector] public int checkingWayPoint = 0;
        [HideInInspector] public float checkNavPointTime = 0f, navPointTimer = 0f;
        [HideInInspector] public float m_TurnAmount;
        [HideInInspector] public Transform[] wayPointListTransform;

        // Perception
        Transform[][] lookAtPositions;
        Transform[] lookAtPositionCentral;
        PerceptionBar perceptionBar;
        Transform eyes;
        Cone m_Cone;
       
        [HideInInspector]public Vector3 playerLastPercieved = new Vector3(1000f, 1000f, 1000f);
        static Vector3 resetPlayerPosition = new Vector3(1000f, 1000f, 1000f);

        public bool hasRadio = false;

        float perceptionPercentage = 0f;
        [HideInInspector] public bool isOtherAlarmed = false;

        public LayerMask visionLayerMask;

        int heardCounter = 0;

        // Saving Game
        [HideInInspector] public GuardSaveComponent m_SaveComponent;

        //Gizmos
        Color statusColor = Color.green;

        // Follows variables found in the parent definition
        // Animation 
        //Animator m_Animator;

        //// AI
        //Brain m_Brain;
        //Blackboard m_Blackboard;

        public void GetNormal()
        {
            if (m_State == GuardState.ALARMED)
                GMController.instance.alarmedGuards--;
            else if (m_State == GuardState.CURIOUS)
                GMController.instance.curiousGuards--;

            heardCounter = 0;
            m_State = GuardState.NORMAL;
            SetBlackboardValue("GuardState", (int)GuardState.NORMAL);
            SetBlackboardValue("IsRelaxing", true);
            LoadStats(normalStats);
            guardAllert.SetActive(true);
            SetBlackboardValue("NavigationPosition", wayPointListTransform[m_Blackboard.GetIntValue("CurrentNavPoint")].position);

            statusColor = Color.green;
        }

        public void GetCurious()
        {
            GMController.instance.curiousGuards++;
            m_State = GuardState.CURIOUS;
            SetBlackboardValue("GuardState", (int)GuardState.CURIOUS);
            SetBlackboardValue("IsRelaxing", false);
            LoadStats(curiousStats);

            statusColor = Color.yellow;
        }

        public void GetAlarmed()
        {
            perceptionPercentage = 100;
            if (m_State == GuardState.CURIOUS)
                GMController.instance.curiousGuards--;

            GMController.instance.alarmedGuards++;
            m_State = GuardState.ALARMED;
            SetBlackboardValue("GuardState", (int)GuardState.ALARMED);
            LoadStats(alarmedStats);
            guardAllert.SetActive(false);
            isOtherAlarmed = false;
            SetBlackboardValue("IsRelaxing", false);

            statusColor = Color.red;
        }

        public void GetDistracted()
        {
            m_State = GuardState.DISTRACTED;
            SetBlackboardValue("GuardState", (int)GuardState.DISTRACTED);
            LoadStats(distractedStats);

            statusColor = Color.blue;
        }

        public void SetOtherAlarmed()
        {
            isOtherAlarmed = true;
            SetBlackboardValue("OtherAlarmed", true);
        }

        public void SetBlackboardValue(string valueName, int value)
        {
            m_Blackboard.SetIntValue(valueName, value);
        }

        public void SetBlackboardValue(string valueName, bool value)
        {
            m_Blackboard.SetBoolValue(valueName, value);
        }

        public void SetBlackboardValue(string valueName, Vector3 value)
        {
            m_Blackboard.SetVector3Value(valueName, value);
        }

        public int GetBlackboardIntValue(string valueName)
        {
            return m_Blackboard.GetIntValue(valueName);
        }

        public bool GetBlackboardBoolValue(string valueName)
        {
            return m_Blackboard.GetBoolValue(valueName);
        }

        public Vector3 GetBlackboardVector3Value(string valueName)
        {
            return m_Blackboard.GetVector3Value(valueName);
        }

        internal GuardState GetState
        {
            get
            {
                return m_State;

            }
        }

        public IEnumerator OutOfSightHysteresis()
        {
            float timer = 0f;
            while (timer < stats.outOfSightHysteresis)
            {
                timer += Time.deltaTime;
                yield return null;
                if (GetBlackboardBoolValue("PlayerInSight"))
                    yield break;
            }

            m_Blackboard.SetBoolValue("PlayerInSight", false);
        }

        private void LoadStats(GuardStats thisStats)
        {
            stats = thisStats;
            m_NavMeshAgent.speed = stats.speed;
            m_NavMeshAgent.angularSpeed = stats.angularSpeed;
            m_NavMeshAgent.acceleration = stats.acceleration;
            m_NavMeshAgent.stoppingDistance = stats.stoppingDistance;
        }

        private void LookAround()
        {
            bool noRaycastHitting = true;

            if (GetBlackboardBoolValue("PlayerInSight") && perceptionPercentage < 100f && GMController.instance.GetGameStatus())
            {
                Debug.Log(GMController.instance.isCharacterPlaying);
                Vector3 direction, distance;
                RaycastHit rayHit;
                bool isRayHitting;
                Ray ray;

                float angle_theta;
                float angle_psi;

                for (int i = 0; i < lookAtPositions[(int)GMController.instance.isCharacterPlaying].Length; i++)
                {
                    //direction = (lookAtPositions[i].position - eyes.position).normalized;
                    distance = (lookAtPositions[(int)GMController.instance.isCharacterPlaying][i].position - eyes.position);
                    angle_psi = Mathf.Atan(distance.y / distance.z) * 180f / Mathf.PI;
                    angle_theta = Mathf.Atan(distance.x / distance.z) * 180f / Mathf.PI;

                    if (angle_psi <= m_Cone.max_psi_Angle && angle_theta <= m_Cone.max_theta_Angle)
                    {
                        direction = distance.normalized;
                        ray = new Ray(eyes.position, direction);
                        isRayHitting = Physics.Raycast(ray, out rayHit, m_Cone.raycastLength, visionLayerMask);
                        isRayHitting = isRayHitting && rayHit.transform.tag == "Player" && 
                            rayHit.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying;

                        Debug.DrawLine(eyes.position, lookAtPositions[(int)GMController.instance.isCharacterPlaying][i].position - eyes.position, Color.red);

                        if (isRayHitting)
                        {
                            noRaycastHitting = false;
                            if (hasRadio)
                            {
                                GMController.instance.UpdatePlayerPosition();
                                playerLastPercieved = GMController.instance.lastPercievedPlayerPosition;
                                UpdateLastPercievedDestination();
                            }
                            else
                            {
                                UpdateMyPlayerPosition();
                            }

                        
                            perceptionPercentage += stats.fillingSpeed * Time.deltaTime;
                        }
                    }
                }

                //direction = (lookAtPositionCentral.position - eyes.position).normalized;
                distance = (lookAtPositionCentral[(int)GMController.instance.isCharacterPlaying].position - eyes.position);
                angle_psi = Mathf.Atan(distance.y / distance.z) * 180f / Mathf.PI;
                angle_theta = Mathf.Atan(distance.x / distance.z) * 180f / Mathf.PI;

                if (angle_psi <= m_Cone.max_psi_Angle && angle_theta <= m_Cone.max_theta_Angle)
                {
                    direction = distance.normalized;
                    ray = new Ray(eyes.position, direction);
                    isRayHitting = Physics.Raycast(ray, out rayHit, m_Cone.raycastLength, visionLayerMask);
                    isRayHitting = isRayHitting && rayHit.transform.tag == "Player" &&
                        rayHit.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying;

                    if (isRayHitting)
                    {
                        noRaycastHitting = false;
                        if (hasRadio)
                        {
                            GMController.instance.UpdatePlayerPosition();
                            playerLastPercieved = GMController.instance.lastPercievedPlayerPosition;
                            UpdateLastPercievedDestination();
                        }
                        else
                        {
                            UpdateMyPlayerPosition();
                        }


                        perceptionPercentage += stats.fillingSpeed * stats.torsoMultiplier * Time.deltaTime;
                    }
                }
            }
           

            if (GetBlackboardBoolValue("IsRelaxing") && noRaycastHitting && perceptionPercentage > 0f)
            {
                perceptionPercentage -= stats.fillingSpeed * stats.noSeeMultiplier * Time.deltaTime;
            }

            perceptionPercentage = Mathf.Clamp(perceptionPercentage, 0f, 100f);
            
        }

        public void CheckNextPoint()
        {
            StartCoroutine(CheckNextPointCO());
        }

        public IEnumerator CheckNextPointCO()
        {
            checkNavPointTime = wayPointList[checkingWayPoint].secondsStaying;

            //Debug.Log("Started waiting coroutine: " + checkNavPointTime);
            while (navPointTimer <= checkNavPointTime)
            {
                navPointTimer += Time.deltaTime;
                if (navPointTimer <= 2f)
                {
                    //float step = normalStats.angularSpeed * Time.deltaTime;
                    float step = normalStats.spotRotatingSpeed * Time.deltaTime;
                    int wayPoint = (checkingWayPoint - 1);
                    if (wayPoint < 0)
                        wayPoint = wayPointList.Count - 1;
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, wayPointList[wayPoint].facingDirection, step, 0.0f);
                    //m_TurnAmount = Mathf.Atan2(newDir.x, newDir.z);
                    m_TurnAmount = (transform.forward - newDir).magnitude * 10f;
                    //m_Animator.SetFloat("Turn", step);
                    m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
                    //m_Animator.SetFloat("Forward", step*5f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }
                else if (navPointTimer >= checkNavPointTime - 2f)
                {
                
                    // start facing the next point of the navigation
                    //float step = normalStats.angularSpeed * Time.deltaTime;
                    float step = normalStats.spotRotatingSpeed * Time.deltaTime;
                    Vector3 targetDir = wayPointListTransform[checkingWayPoint].position - transform.position;
                    targetDir = new Vector3(targetDir.x, transform.position.y, targetDir.z);
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                    //m_TurnAmount = Mathf.Atan2(newDir.x, newDir.z);
                    m_TurnAmount = (transform.forward - newDir).magnitude * 10f;
                    //m_Animator.SetFloat("Turn", step);
                    m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
                    //m_Animator.SetFloat("Forward", step*5f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }

                if (m_State == GuardState.ALARMED || m_State == GuardState.CURIOUS)
                {
                    SetBlackboardValue("CheckingNavPoint", false);
                    SetBlackboardValue("WaitingCoroutineRunning", false);

                    yield break;

                }

                yield return null;
            }

            
            //Debug.Log("finished waiting");
            navPointTimer = 0;
            SetBlackboardValue("CheckingNavPoint", false);
            SetBlackboardValue("WaitingCoroutineRunning", false);
            yield return null;
        }

        // method used to manage the state of the guard from the gauge of perception
        private void ChangeStateFromGauge()
        {
            if(perceptionPercentage >=0 && perceptionPercentage< 25)
            {
                GetNormal();
            }
            else if((perceptionPercentage >= 25 && perceptionPercentage < 75) && GetState != GuardState.ALARMED && GetState != GuardState.CURIOUS)
            {
                GetCurious();
            }
            else if((perceptionPercentage >= 75 && perceptionPercentage < 100) && GetState != GuardState.ALARMED)
            {
                GetAlarmed();
            }
        }

        // update the personal known positoin of the player
        public void UpdateMyPlayerPosition()
        {
            playerLastPercieved = GMController.instance.players[(int)GMController.instance.isCharacterPlaying].transform.position;
            UpdateLastPercievedDestination();
        }

        // update the personal known position of the player on the blackboard
        public void UpdateLastPercievedDestination()
        {
            m_Blackboard.SetVector3Value("LastPercievedPosition", playerLastPercieved);
        }

        // reset the personal known positoin of the player
        public void ResetMyPlayerPosition()
        {
            playerLastPercieved = resetPlayerPosition;
            ResetLastPercievedPosition();
        }

        // reset the personal known position of the player on the blackboard
        public void ResetLastPercievedPosition()
        {
            m_Blackboard.SetVector3Value("LastPercievedPosition", playerLastPercieved);
        }

        // get a random point to check when reached the last precieved position
        public void GetRandomPoint(out Vector3 result)
        {
            int i = 0;
            result = transform.position;

            for (i = 0; i < 30; i++)
            {
                Vector3 randomPoint = GetBlackboardVector3Value("LastPercievedPosition") + Random.insideUnitSphere * alarmedStats.localSearchRange;
                randomPoint = new Vector3(randomPoint.x, transform.position.y + 1, randomPoint.z);
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 2.0f, NavMesh.AllAreas) && Vector3.Distance(transform.position, randomPoint) > 10)
                {
                    result = hit.position;
                    break;
                }
            }

        }

        // Updates the pointed nav point from the blackboard value
        public override void UpdateNavPoint()
        {
            checkingWayPoint = m_Blackboard.GetIntValue("CurrentNavPoint");
            nextWayPoint = (m_Blackboard.GetIntValue("CurrentNavPoint") + 1) % wayPointListTransform.Length;
            SetBlackboardValue("NavigationPosition", wayPointListTransform[checkingWayPoint].position);
            m_NavMeshAgent.SetDestination(wayPointListTransform[checkingWayPoint].position);
            m_NavMeshAgent.isStopped = true;
        }

        // Commands to reach the point
        public override void ReachNavPoint()
        {
            m_NavMeshAgent.destination = GetBlackboardVector3Value("NavigationPosition");
            m_NavMeshAgent.isStopped = false;
        }

        public void DefeatPlayer()
        {
            Debug.Log("DEFEAT");
            characterInterfaces[(int)GMController.instance.isCharacterPlaying].DefeatPlayer();
        }

        private void UpdatePerceptionUI()
        {
            perceptionBar.SetFillingPerc(Mathf.Clamp(perceptionPercentage, 0f, 100f));
        }

        public void SetPerceptionToValue(float value)
        {
            perceptionPercentage = value;
        }

        public void HearPlayer()
        {
            heardCounter++;
            perceptionPercentage += 20f;

            if (heardCounter >= 3)
            {
                GetAlarmed();
            }
        }

        public void ResetForReload(int wayPoint)
        {
            m_Brain.decisionMaker.m_Blackboard = new GuardBlackboard();
            m_Blackboard = m_Brain.decisionMaker.m_Blackboard;
            m_Blackboard.m_Agent = this;

            perceptionPercentage = 0;

            SetBlackboardValue("CurrentNavPoint", wayPoint);
            SetBlackboardValue("RandomPick", randomPick);
            SetBlackboardValue("NumberOfNavPoints", wayPointList.Count);
            GetNormal();
        }

        private void Awake()
        {
            // Get components reference
            m_NavMeshAgent = GetComponent<NavMeshAgent>();
            perceptionBar = GetComponentInChildren<PerceptionBar>();
            eyes = TransformDeepChildExtension.FindDeepChild(transform, "eyes");
            m_Cone = TransformDeepChildExtension.FindDeepChild(transform, "Cone").GetComponent<Cone>();
            m_Animator = GetComponent<Animator>();

            m_Brain = GetComponent<Brain>();
            m_Brain.decisionMaker = Instantiate(m_Brain.decisionMaker);
            m_Brain.decisionMaker.m_Blackboard = new GuardBlackboard();
            m_Blackboard = m_Brain.decisionMaker.m_Blackboard;
            m_Blackboard.m_Agent = this;
            guardAllert = transform.Find("AllertRange").gameObject;

            // Get the transform of the patrol nav points
            wayPointListTransform = new Transform[wayPointList.Count];
            for (int i = 0; i < wayPointListTransform.Length; i++)
            {
                wayPointListTransform[i] = wayPointList[i].transform;
            }
            
            // Finds the position the guards are looking at
            GameObject[] lookAtPositionsObj = GameObject.FindGameObjectsWithTag("LookAtPosition");
            lookAtPositions = new Transform[2][];
            lookAtPositions[0] = new Transform[lookAtPositionsObj.Length/2];
            lookAtPositions[1] = new Transform[lookAtPositionsObj.Length/2];

            int boyIdx = 0, motherIdx = 0;
            
            for (int i = 0; i < lookAtPositionsObj.Length; i++)
            {
                // find parent name boy or mother and assign accordingly
                // create two counter for the array position
                Transform lookAt = lookAtPositionsObj[i].transform;
                if (lookAt.root.gameObject.name == "Boy")
                {
                    lookAtPositions[(int)CharacterActive.Boy][boyIdx] = lookAt;
                    boyIdx++;

                }
                else if (lookAt.root.gameObject.name == "Mother")
                {
                    lookAtPositions[(int)CharacterActive.Mother][motherIdx] = lookAt;
                    motherIdx++;
                }

            }

            GameObject[] lookAtPositionsCentralObj = GameObject.FindGameObjectsWithTag("LookAtPositionCentral");
            lookAtPositionCentral = new Transform[lookAtPositionsCentralObj.Length];
            for (int i = 0; i < lookAtPositionsCentralObj.Length; i++)
            {
                Transform lookAtCentral = lookAtPositionsCentralObj[i].transform;
                if (lookAtCentral.root.gameObject.name == "Boy")
                {
                    lookAtPositionCentral[(int)CharacterActive.Boy] = lookAtCentral;

                }
                else if (lookAtCentral.root.gameObject.name == "Mother")
                {
                    lookAtPositionCentral[(int)CharacterActive.Mother] = lookAtCentral;
                }
            }
        }

        private void Start()
        {
            LoadStats(normalStats);
            m_NavMeshAgent.destination = wayPointListTransform[0].position;
            SetBlackboardValue("RandomPick", randomPick);
            SetBlackboardValue("NumberOfNavPoints", wayPointList.Count);

            characterInterfaces = GMController.instance.m_CharacterInterfaces;

        }

        private void Update()
        {
            LookAround();
            UpdatePerceptionUI();
            ChangeStateFromGauge();
            //m_Animator.SetFloat("Forward", m_NavMeshAgent.speed);

            Vector3 move = m_NavMeshAgent.velocity;
            if (move.magnitude > 1f) move.Normalize();
            move = transform.InverseTransformDirection(move);
            move = Vector3.ProjectOnPlane(move, Vector3.down);
            m_TurnAmount = Mathf.Atan2(move.x, move.z);
            float m_ForwardAmount = move.z;
            if (m_State == GuardState.NORMAL)
                m_ForwardAmount = Mathf.Clamp(m_ForwardAmount, 0, 0.5f);

            m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
            m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        }

        private void OnDrawGizmosSelected()
        {
            if (m_Blackboard != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere( GetBlackboardVector3Value("LastPercievedPosition") , 1);

                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(GetBlackboardVector3Value("NavigationPosition"), 1);
            }

            Gizmos.color = statusColor;
            Gizmos.DrawWireSphere(transform.position, 0.6f);
        }

    }

    
}

