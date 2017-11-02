using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/Animator/ResetTurn")]
    public class AnimSetTurn : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            UpdateAnimatorForStartPatrol(controller);
        }

        private void UpdateAnimatorForStartPatrol(EnemiesAIStateController controller)
        {
            //controller.m_AgentController.m_Animator.SetBool("isPatrolling", true);
            controller.m_AgentController.m_Animator.SetFloat("Turn", 0, 0.1f, Time.deltaTime);
        }
    }
}
