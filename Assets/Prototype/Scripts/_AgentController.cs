using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class _AgentController : MonoBehaviour {

    public List<Transform> wayPointList;
    public Transform eyes;

    [HideInInspector] public Transform[] lookAtPositions;
    [HideInInspector] public Transform lookAtPositionCentral;
    [HideInInspector] public bool hasHeardPlayer = false;
    [HideInInspector] public bool hasSeenPlayer = false;
    [HideInInspector] public bool isInSight = false;
    [HideInInspector] public int nextWayPoint = 0;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public NavMeshAgent m_NavMeshAgent;
    [HideInInspector] public MyAgentStats agentStats;
    [HideInInspector] public float sightPercentage = 0f;

    public MyAgentStats patrolStats;
    public MyAgentStats checkForPositionStats;

    private MyAgentStats loadingStats;
    private PerceptionBar perceptionBar;

    private void Awake()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        GameObject[] lookAtPositionsObj = GameObject.FindGameObjectsWithTag("LookAtPosition");
        lookAtPositions = new Transform[lookAtPositionsObj.Length];
        for (int i = 0; i < lookAtPositionsObj.Length; i++)
        {
            lookAtPositions[i] = lookAtPositionsObj[i].transform;
        }
        lookAtPositionCentral = GameObject.FindGameObjectsWithTag("LookAtPositionCentral")[0].transform;
        UpdateStats(patrolStats);
        perceptionBar = GetComponentInChildren<PerceptionBar>();
    }

    public void LoadNavmeshStats()
    {
        m_NavMeshAgent.speed = agentStats.speed;
        m_NavMeshAgent.angularSpeed = agentStats.angularSpeed;
        m_NavMeshAgent.acceleration = agentStats.acceleration;
        m_NavMeshAgent.stoppingDistance = agentStats.stoppingDistance;
    }

    public void UpdateStats(MyAgentStats stats)
    {
        agentStats = stats;
        LoadNavmeshStats();
    }

    public void UpdateStats(string statsName)
    {
        switch (statsName)
        {
            case "patrol":
                agentStats = patrolStats;
                break;
            case "checkForNoise":
                agentStats = patrolStats;
                break;
            default:
                break;
        }

        LoadNavmeshStats();

    }

    void Update()
    {
        bool noRaycastHitting = true;
        if (isInSight && sightPercentage < 100f)
        {
            Vector3 direction;

            for (int i = 0; i < lookAtPositions.Length; i++)
            {
                direction = (lookAtPositions[i].position - transform.position).normalized;

                if (Physics.Raycast(eyes.position, direction))
                {
                    sightPercentage += agentStats.fillingSpeed;
                    noRaycastHitting = false;
                }
            }

            direction = (lookAtPositionCentral.position - transform.position).normalized;
            if (Physics.Raycast(eyes.position, direction))
            {
                sightPercentage += agentStats.fillingSpeed * 10.0f;
                noRaycastHitting = false;
            }
        }

        if (noRaycastHitting && sightPercentage > 100f)
        {
            sightPercentage -= agentStats.fillingSpeed;
        }
        

        sightPercentage = Mathf.Clamp(sightPercentage, 0f, 100f);
        perceptionBar.SetFillingPerc(sightPercentage);

    }

}
