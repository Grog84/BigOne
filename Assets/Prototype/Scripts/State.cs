using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Prototype/State")]
public class State : ScriptableObject {

    public _Action[] actions;
    public _Action[] enterActions;
    public _Action[] exitActions;
    public Transition[] transitions;
    public Color sceneGizmosColor = Color.gray;

    // Every time we are calling this function we are evaluating all the actions and decisions connected to the state
    public void UpdateState(CharacterStateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    public void UpdateState(EnemiesAIStateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    public void UpdateState(GMStateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    protected virtual void DoActions(CharacterStateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(controller);
        }
    }

    protected virtual void DoActions(EnemiesAIStateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(controller);
        }
    }

    protected virtual void DoActions(GMStateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(controller);
        }
    }

    private void CheckTransitions(CharacterStateController controller)
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

    private void CheckTransitions(EnemiesAIStateController controller)
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

    private void CheckTransitions(GMStateController controller)
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

    public void OnExitState(CharacterStateController controller)
    {
        for (int i = 0; i < exitActions.Length; i++)
        {
            exitActions[i].Execute(controller);
        }
    }

    public void OnExitState(EnemiesAIStateController controller)
    {
        for (int i = 0; i < exitActions.Length; i++)
        {
            exitActions[i].Execute(controller);
        }
    }

    public void OnExitState(GMStateController controller)
    {
        for (int i = 0; i < exitActions.Length; i++)
        {
            exitActions[i].Execute(controller);
        }
    }

    public void OnEnterState(CharacterStateController controller)
    {
        for (int i = 0; i < enterActions.Length; i++)
        {
            enterActions[i].Execute(controller);
        }
    }

    public void OnEnterState(EnemiesAIStateController controller)
    {
        for (int i = 0; i < enterActions.Length; i++)
        {
            enterActions[i].Execute(controller);
        }
    }

    public void OnEnterState(GMStateController controller)
    {
        for (int i = 0; i < enterActions.Length; i++)
        {
            enterActions[i].Execute(controller);
        }
    }
}
