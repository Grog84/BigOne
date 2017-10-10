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
        State[] foundItems = (State[])Resources.FindObjectsOfTypeAll(typeof(State));
        inactiveState = foundItems[0];
        inactiveState = foundItems[1];
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
