using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/Animator/ResetForward")]
    public class AnimSetForward : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            UpdateAnimatorForStartPatrol(controller);
        }

        private void UpdateAnimatorForStartPatrol(EnemiesAIStateController controller)
        {
            //controller.m_AgentController.m_Animator.SetBool("isPatrolling", true);
            controller.m_AgentController.m_Animator.SetFloat("Forward", 0, 0.1f, Time.deltaTime);
        }
    }
}
