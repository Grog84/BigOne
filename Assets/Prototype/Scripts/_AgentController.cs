using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class _AgentController : MonoBehaviour {

    public List<NavPoint> wayPointList;
    public Transform eyes;

    [HideInInspector] public Transform[] lookAtPositions;
    [HideInInspector] public Transform lookAtPositionCentral;
    [HideInInspector] public Transform[] wayPointListTransform;
    [HideInInspector] public bool hasHeardPlayer = false;
    [HideInInspector] public bool hasSeenPlayer = false;

    [HideInInspector] public bool isPlayerInSight = false;
    [HideInInspector] public bool isSuspicious = false, isAlarmed = false;

    [HideInInspector] public int nextWayPoint = 0;
    [HideInInspector] public bool isCheckingNavPoint = false;

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
        wayPointListTransform = new Transform[wayPointList.Count];
        for (int i = 0; i < wayPointListTransform.Length; i++)
        {
            wayPointListTransform[i] = wayPointList[i].transform;
        }
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

    private IEnumerator WaitAtNavPoint()
    {
        Vector3 oldDirection = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        float rotationDuration = 1f;
        transform.DORotate(wayPointListTransform[nextWayPoint].eulerAngles, rotationDuration);
        yield return new WaitForSeconds(rotationDuration);
        yield return new WaitForSeconds(wayPointList[nextWayPoint].secondsStaying);
        transform.DORotate(oldDirection, rotationDuration);
        yield return new WaitForSeconds(rotationDuration);
        isCheckingNavPoint = false;
    }

    void Update()
    {
        bool noRaycastHitting = true;
        if (isPlayerInSight && sightPercentage < 100f)
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

        if (isCheckingNavPoint)
        {
            StartCoroutine(WaitAtNavPoint());
        }

        sightPercentage = Mathf.Clamp(sightPercentage, 0f, 100f);
        perceptionBar.SetFillingPerc(sightPercentage);

    }

}
