﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Prototype/State")]
public class State : ScriptableObject {

    public _Action[] actions;
    public _Action[] exitActions;
    public _Action[] enterActions;
    public Transition[] transitions;
    public Color sceneGizmosColor = Color.gray;

    // Every time we are calling this function we are evaluating all the actions and decisions connected to the state
    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }

    public void OnExitState(StateController controller)
    {
        for (int i = 0; i < exitActions.Length; i++)
        {
            exitActions[i].Execute(controller);
        }
    }

    public void OnEnterState(StateController controller)
    {
        for (int i = 0; i < enterActions.Length; i++)
        {
            enterActions[i].Execute(controller);
        }
    }
}
