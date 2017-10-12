using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class _AgentController : MonoBehaviour {

    public List<Transform> wayPointList;
    public Transform eyes;
    public GameObject player;

    [HideInInspector] public GameObject[] lookAtPositions;
    [HideInInspector] public GameObject lookAtPositionCentral;
    [HideInInspector] public bool hasHeardPlayer = false;
    [HideInInspector] public bool hasSeenPlayer = false;
    [HideInInspector] public int nextWayPoint = 0;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public NavMeshAgent m_NavMeshAgent;
    [HideInInspector] public MyAgentStats agentStats;

    public MyAgentStats patrolStats;
    public MyAgentStats checkForPositionStats;

    private MyAgentStats loadingStats;

    private void Awake()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        UpdateStats(patrolStats);
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

}
