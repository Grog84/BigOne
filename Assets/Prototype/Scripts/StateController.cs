using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    public State currentState;

    public State remainState;
    [HideInInspector] public float stateTimeElapsed;

    private bool isActive = true;

	
	// Update is called once per frame
	protected virtual void Update () {

        if (!isActive)
            return;

	}

    public virtual void TransitionToState(State nextState)
    {
    }

    protected void OnExitState()
    {
        stateTimeElapsed = 0;
    }

}
