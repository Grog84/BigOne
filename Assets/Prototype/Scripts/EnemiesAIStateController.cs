using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAIStateController : StateController {

    public MyAgentStats agentStats;
    public List<Transform> wayPointList;
    public Transform eyes;

    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;

    // Is it necessary?
    protected override void Awake()
    {
        base.Awake();
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
            OnExitState();
        }
    }

    protected override void Update()
    {
        base.Update();
        currentState.UpdateState(this);
    }
}
