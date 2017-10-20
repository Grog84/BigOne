using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesAIStateController : StateController {

    [HideInInspector] public _AgentController m_AgentController;
    [HideInInspector] public float stateTimer = 0f;

    [Space(5)]
    [Header("States For Saving")]
    public State patrolState;
    public State checkNavPoint;

    protected override void Awake()
    {
        base.Awake();
        lastActiveState = currentState;
        m_AgentController = GetComponent<_AgentController>();
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

}
