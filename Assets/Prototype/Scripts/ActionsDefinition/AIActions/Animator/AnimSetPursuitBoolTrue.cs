using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/Animator/ActivatePursuit")]
    public class AnimSetPursuitBoolTrue : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            UpdateAnimatorForStartPursuit(controller);
        }

        private void UpdateAnimatorForStartPursuit(EnemiesAIStateController controller)
        {
            //controller.m_AgentController.m_Animator.SetBool("isChasing", true);
            controller.m_AgentController.m_Animator.SetFloat("Forward", controller.m_AgentController.m_ForwardAmount, 0.1f, Time.deltaTime);
            controller.m_AgentController.m_Animator.SetFloat("Turn", controller.m_AgentController.m_TurnAmount, 0.1f, Time.deltaTime);

        }
    }
}
