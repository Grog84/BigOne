using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SaveGame;

namespace AI
{
    enum GuardState { NORMAL, CURIOUS, ALARMED, DISTRACTED};

    public class Guard : MonoBehaviour
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

        // State
        GuardState m_State = GuardState.NORMAL;
        GuardStats stats;

        //Navigation
        NavMeshAgent m_NavMeshAgent;

        [HideInInspector] public Transform[] wayPointListTransform;

        // Perception
        Transform[] lookAtPositions;
        Transform lookAtPositionCentral;
        PerceptionBar perceptionBar;
        Transform eyes;

        bool isPerceptionBlocked = false;

        float perceptionPercentage = 0f;
        [HideInInspector] public bool isPlayerInSight = false;

        // Saving Game
        [HideInInspector] public GuardSaveComponent m_SaveComponent;

        // Animation
        Animator m_Animator;


        public void GetNormal()
        {
            m_State = GuardState.NORMAL;
            LoadStats(normalStats);
        }

        public void GetCurious()
        {
            m_State = GuardState.CURIOUS;
            LoadStats(curiousStats);
        }

        public void GetAlarmed()
        {
            m_State = GuardState.ALARMED;
            LoadStats(alarmedStats);
        }

        public void GetDistracted()
        {
            m_State = GuardState.DISTRACTED;
            LoadStats(distractedStats);
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
                        perceptionPercentage += stats.fillingSpeed * Time.deltaTime;
                        noRaycastHitting = false;
                        GMController.instance.UpdatePlayerPosition();
                    }
                }

                direction = (lookAtPositionCentral.position - transform.position).normalized;
                if (Physics.Raycast(eyes.position, direction))
                {
                    perceptionPercentage += stats.fillingSpeed * stats.torsoMultiplier * Time.deltaTime;
                    noRaycastHitting = false;
                    GMController.instance.UpdatePlayerPosition();
                }
            }

            if (noRaycastHitting && perceptionPercentage > 0f)
            {
                perceptionPercentage -= stats.fillingSpeed * stats.noSeeMultiplier * Time.deltaTime;
            }

            perceptionPercentage = Mathf.Clamp(perceptionPercentage, 0f, 100f);
            
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
        }
    }

    
}

