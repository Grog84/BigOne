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
        public List<NavPoint> wayPointList;

        [Space(10)]
        [Header("Agent States Parameters")]
        public GuardStats normalStats;
        public GuardStats curiousStats;
        public GuardStats alarmedStats;
        public GuardStats distractedStats;

        [Space(10)]
        [Header("Agent Perception Component")]
        public GameObject guardAllert;

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
        bool isPerceptionBlocked = false;

        float perceptionPercentage = 0f;
        [HideInInspector] public bool isPlayerInSight = false;
        [HideInInspector] public bool isOtherAlarmed = false;
        // Saving Game
        [HideInInspector] public GuardSaveComponent m_SaveComponent;

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
            m_Blackboard.SetIntValue("GuardState", (int)GuardState.NORMAL);
            LoadStats(normalStats);
            guardAllert.SetActive(true);
        }

        public void GetCurious()
        {
            GMController.instance.curiousGuards++;
            m_State = GuardState.CURIOUS;
            m_Blackboard.SetIntValue("GuardState", (int)GuardState.CURIOUS);
            LoadStats(curiousStats);
        }

        public void GetAlarmed()
        {
            perceptionPercentage = 100;
            if (m_State == GuardState.CURIOUS)
                GMController.instance.curiousGuards--;

            GMController.instance.alarmedGuards++;
            m_State = GuardState.ALARMED;
            m_Blackboard.SetIntValue("GuardState", (int)GuardState.ALARMED);
            LoadStats(alarmedStats);
            guardAllert.SetActive(false);
            isOtherAlarmed = false;
        }

        public void GetDistracted()
        {
            m_State = GuardState.DISTRACTED;
            m_Blackboard.SetIntValue("GuardState", (int)GuardState.DISTRACTED);
            LoadStats(distractedStats);
        }

        public void SetPlayerInSight()
        {
            isPlayerInSight = true;
            m_Blackboard.SetBoolValue("PlayerInSight", true);
        }

        public void SetPlayerOutOfSight()
        {
            isPlayerInSight = false;
            StartCoroutine(OutOfSightHysteresis());
        }

        public void SetOtherAlarmed()
        {
            isOtherAlarmed = true;
            m_Blackboard.SetBoolValue("OtherAlarmed", true);
        }
        
        public void GetOtherAlarmed()
        {
            isOtherAlarmed = m_Blackboard.GetBoolValue("OtherAlarmed");
        }

        internal GuardState GetState
        {
            get
            {
                return m_State;

            }
        }

        IEnumerator OutOfSightHysteresis()
        {
            float timer = 0f;
            while (timer < stats.outOfSightHysteresis)
            {
                timer += Time.deltaTime;
                yield return null;
                if (isPlayerInSight)
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

            if (isPlayerInSight && perceptionPercentage < 100f && GMController.instance.GetGameStatus())
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

                        if (!isPerceptionBlocked)
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

                    if (!isPerceptionBlocked)
                        perceptionPercentage += stats.fillingSpeed * stats.torsoMultiplier * Time.deltaTime;
                }
            }

            if (!isPerceptionBlocked && noRaycastHitting && perceptionPercentage > 0f)
            {
                perceptionPercentage -= stats.fillingSpeed * stats.noSeeMultiplier * Time.deltaTime;
            }

            perceptionPercentage = Mathf.Clamp(perceptionPercentage, 0f, 100f);
            
        }

        public void CheckNextPoint()
        {
            navPointTimer += Time.deltaTime;

            if (navPointTimer <= 2f)
            {
                float step = normalStats.angularSpeed * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, wayPointList[checkingWayPoint].facingDirection, step, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                m_TurnAmount = Mathf.Atan2(newDir.x, newDir.z);
            }
            else if (navPointTimer >= checkNavPointTime - 2f)
            {
                // start facing the next point of the navigation
                float step = normalStats.angularSpeed * Time.deltaTime;
                Vector3 targetDir = wayPointListTransform[nextWayPoint].position - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                transform.rotation = Quaternion.LookRotation(newDir);
                m_TurnAmount = Mathf.Atan2(newDir.x, newDir.z);
            }

            if (navPointTimer >= checkNavPointTime)
            {
                navPointTimer = 0;
                m_Blackboard.SetBoolValue("CheckingNavPoint", false);
            }
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
            for (int i = 0; i < 30; i++)
            {
                Vector3 randomPoint = transform.position + Random.insideUnitSphere * alarmedStats.localSearchRange;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                }
            }
            result = transform.position;
        }

        private void UpdatePerceptionUI()
        {
            perceptionBar.SetFillingPerc(Mathf.Clamp(perceptionPercentage, 0f, 100f));
        }

        private void Awake()
        {
            // Get components reference
            m_NavMeshAgent = GetComponent<NavMeshAgent>();
            perceptionBar = GetComponentInChildren<PerceptionBar>();
            eyes = TransformDeepChildExtension.FindDeepChild(transform, "eyes");
            m_Animator = GetComponent<Animator>();
            m_Brain = GetComponent<Brain>();
            m_Blackboard = m_Brain.decisionMaker.m_Blackboard;

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
        }

        private void Update()
        {
            LookAround();
            UpdatePerceptionUI();
            ChangeStateFromGauge();
            GetOtherAlarmed();
        }
    }

    
}

