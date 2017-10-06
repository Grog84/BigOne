using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesAIStateController : StateController {

    public MyAgentStats agentStats;
    public List<Transform> wayPointList;
    public Transform eyes;

    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    protected void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmosColor;
            Gizmos.DrawWireSphere(eyes.position, agentStats.lookSphereCastRadius);
        }
    }

    public override void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState.OnExitState(this);
            currentState = nextState;
            currentState.OnEnterState(this);
            lastActiveState = currentState;
            OnExitState();
        }
    }

    public override void Update()
    {
        base.Update();

        if (!checkIfGameActive.Decide(this) && currentState != inactiveState)
        {
            TransitionToState(inactiveState);
        }
        else if (checkIfGameActive.Decide(this) && currentState == inactiveState)
        {
            TransitionToState(lastActiveState);
        }

        currentState.UpdateState(this);
    }

    //void Update()
    //{

    //    if (!checkIfGameActive.Decide(this) && currentState != inactiveState)
    //    {
    //        TransitionToState(inactiveState);
    //    }
    //    else if (checkIfGameActive.Decide(this) && currentState == inactiveState)
    //    {
    //        TransitionToState(lastActiveState);
    //    }

    //    currentState.UpdateState(this);
    //}
}
