using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/Animator/ActivatePatrol")]
    public class AnimSetPatrolBoolTrue : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            UpdateAnimatorForStartPatrol(controller);
        }

        private void UpdateAnimatorForStartPatrol(EnemiesAIStateController controller)
        {
            //controller.m_AgentController.m_Animator.SetBool("isPatrolling", true);
            controller.m_AgentController.m_Animator.SetFloat("Forward", Mathf.Clamp(controller.m_AgentController.m_ForwardAmount, 0f, 0.5f), 0.1f, Time.deltaTime);
            controller.m_AgentController.m_Animator.SetFloat("Turn", Mathf.Clamp(controller.m_AgentController.m_TurnAmount, -0.5f, 0.5f), 0.1f, Time.deltaTime);
        }
    }
}
