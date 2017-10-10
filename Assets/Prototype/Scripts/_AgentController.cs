using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class _AgentController : MonoBehaviour {

    public MyAgentStats patrolStats;
    public MyAgentStats checkForPositionStats;
    public MyAgentStats agentStats;
    public List<Transform> wayPointList;
    public Transform eyes;

    [HideInInspector] public bool hasHeardPlayer = false;
    [HideInInspector] public bool hasSeenPlayer = false;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    private NavMeshAgent m_NavMeshAgent;
    private MyAgentStats loadingStats;

    private void Awake()
    {
        m_NavMeshAgent.GetComponent<NavMeshAgent>();
    }

    public void loadStats(MyAgentStats stats)
    {
        m_NavMeshAgent.speed = stats.speed;
        m_NavMeshAgent.angularSpeed = stats.angularSpeed;
        m_NavMeshAgent.acceleration = stats.acceleration;
        m_NavMeshAgent.stoppingDistance = stats.stoppingDistance;
        

    }

    public void loadStats(string statsName)
    {
        switch (statsName)
        {
            case "patrol":
                loadingStats = patrolStats;
                break;
            case "checkForNoise":
                loadingStats = patrolStats;
                break;
            default:
                break;
        }
        m_NavMeshAgent.speed = loadingStats.speed;
        m_NavMeshAgent.angularSpeed = loadingStats.angularSpeed;
        m_NavMeshAgent.acceleration = loadingStats.acceleration;
        m_NavMeshAgent.stoppingDistance = loadingStats.stoppingDistance;


    }

}
