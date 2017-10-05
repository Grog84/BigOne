﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMStateController : StateController {

    [HideInInspector] public GMController m_GM;

    protected void Awake()
    {
        m_GM = GetComponent<GMController>();
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
