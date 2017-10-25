﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Prototype/State")]
    public class State : ScriptableObject
    {

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
                bool decisionSucceeded = true;
                for (int j = 0; j < transitions[i].decision.Length; j++)
                {
                    decisionSucceeded = decisionSucceeded && transitions[i].decision[j].Decide(controller);
                }
                    

                if (decisionSucceeded)
                {
                    if (transitions[i].trueState == null)
                    {
                        Debug.Log("ecco");
                        Debug.Log(this);
                    }
                    controller.TransitionToState(transitions[i].trueState);
                }
                else
                {
                    if (transitions[i].falseState == null)
                        Debug.Log("ecco");
                    controller.TransitionToState(transitions[i].falseState);
                }
            }
        }

        private void CheckTransitions(EnemiesAIStateController controller)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionSucceeded = true;
                for (int j = 0; j < transitions[i].decision.Length; j++)
                {
                    decisionSucceeded = decisionSucceeded && transitions[i].decision[j].Decide(controller);
                }

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
                bool decisionSucceeded = true;
                for (int j = 0; j < transitions[i].decision.Length; j++)
                {
                    decisionSucceeded = decisionSucceeded && transitions[i].decision[j].Decide(controller);
                }

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
}