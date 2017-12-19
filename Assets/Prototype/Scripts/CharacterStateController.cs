using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Character;

namespace StateMachine
{
    public class CharacterStateController : StateController
    {

        public CharacterActive thisCharacter;

        [HideInInspector] public CharacterStats characterStats;
        [HideInInspector] public State gameStartState;
        [HideInInspector] public State defeatedState;
        [HideInInspector] public _CharacterController m_CharacterController;
        [HideInInspector] public NavMeshAgent navMeshAgent;

        // Use this for initialization
        protected override void Awake()
        {
            base.Awake();
            inactiveState = (State)Resources.Load("Inactive");
            navMeshAgent = GetComponent<NavMeshAgent>();

            lastActiveState = currentState;

            m_CharacterController = GetComponent<_CharacterController>();   

            if (thisCharacter == CharacterActive.Boy)
                gameStartState = (State)Resources.Load("GameStart_Boy");
            else if (thisCharacter == CharacterActive.Mother)
                gameStartState = (State)Resources.Load("GameStart_Mother");
            defeatedState = (State)Resources.Load("Defeated");

        }

        private void Start()
        {
            characterStats = m_CharacterController.m_CharStats;
        }

        public override void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState.OnExitState(this);
                currentState = nextState;
                currentState.OnEnterState(this);
                if (currentState != inactiveState)
                    lastActiveState = currentState;
                OnExitState();
            }
        }

        public override void Update()
        {
            base.Update();

            if (!checkIfGameActive.Decide(this) && (currentState != inactiveState && currentState != gameStartState && currentState != defeatedState))
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
}
