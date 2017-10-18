using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    public State currentState;
    public Decision checkIfGameActive;

    [HideInInspector] public State inactiveState;  // could it be loaded from te resources?
    [HideInInspector] public State remainState;    // could it be loaded from te resources?
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public State lastActiveState;

    protected bool isActive = true;

    protected virtual void Awake()
    {
        inactiveState = (State)Resources.Load("Inactive"); 
        remainState = (State)Resources.Load("RemainInState");
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    public virtual void TransitionToState(State nextState)
    {
    }

    protected void OnExitState()
    {
        stateTimeElapsed = 0;
    }

}
