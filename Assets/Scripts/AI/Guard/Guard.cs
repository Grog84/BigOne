using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SaveGame;

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
        Transform[] lookAtPositions;
        Transform lookAtPositionCentral;
        PerceptionBar perceptionBar;
        Transform eyes;
       
        [HideInInspector]public Vector3 playerLastPercieved = new Vector3(1000f, 1000f, 1000f);
        static Vector3 resetPlayerPosition = new Vector3(1000f, 1000f, 1000f);

        public bool hasRadio = false;

        float perceptionPercentage = 0f;
        [HideInInspector] public bool isOtherAlarmed = false;

        // Saving Game
        [HideInInspector] public GuardSaveComponent m_SaveComponent;

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

            m_State = GuardState.NORMAL;
            SetBlackboardValue("GuardState", (int)GuardState.NORMAL);
            SetBlackboardValue("IsRelaxing", true);
            LoadStats(normalStats);
            guardAllert.SetActive(true);
            SetBlackboardValue("NavigationPosition", wayPointListTransform[m_Blackboard.GetIntValue("CurrentNavPoint")].position);
        }

        public void GetCurious()
        {
            GMController.instance.curiousGuards++;
            m_State = GuardState.CURIOUS;
            SetBlackboardValue("GuardState", (int)GuardState.CURIOUS);
            SetBlackboardValue("IsRelaxing", false);
            LoadStats(curiousStats);
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
        }

        public void GetDistracted()
        {
            m_State = GuardState.DISTRACTED;
            SetBlackboardValue("GuardState", (int)GuardState.DISTRACTED);
            LoadStats(distractedStats);
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
                
                Vector3 direction;

                for (int i = 0; i < lookAtPositions.Length; i++)
                {
                    direction = (lookAtPositions[i].position - transform.position).normalized;

                    if (Physics.Raycast(eyes.position, direction))
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

                direction = (lookAtPositionCentral.position - transform.position).normalized;
                if (Physics.Raycast(eyes.position, direction))
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

        private void Awake()
        {
            // Get components reference
            m_NavMeshAgent = GetComponent<NavMeshAgent>();
            perceptionBar = GetComponentInChildren<PerceptionBar>();
            eyes = TransformDeepChildExtension.FindDeepChild(transform, "eyes");
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
            lookAtPositions = new Transform[lookAtPositionsObj.Length];
            for (int i = 0; i < lookAtPositionsObj.Length; i++)
            {
                lookAtPositions[i] = lookAtPositionsObj[i].transform;
            }
            lookAtPositionCentral = GameObject.FindGameObjectsWithTag("LookAtPositionCentral")[0].transform;

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
        }

    }

    
}

