﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterStateController : StateController {

    public CharacterStats characterStats;

    [HideInInspector] public _CharacterController m_CharacterController;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    [HideInInspector] public float m_WalkSoundrange_sq;   // squared value
    [HideInInspector] public float m_CrouchSoundrange_sq; // squared value
    [HideInInspector] public float m_RunSoundrange_sq;    // squared value

    // Use this for initialization
    protected void Awake ()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        m_WalkSoundrange_sq = characterStats.m_WalkSoundrange * characterStats.m_WalkSoundrange;   
        m_CrouchSoundrange_sq = characterStats.m_CrouchSoundrange * characterStats.m_CrouchSoundrange;
        m_RunSoundrange_sq = characterStats.m_RunSoundrange * characterStats.m_RunSoundrange;

        lastActiveState = currentState;
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
