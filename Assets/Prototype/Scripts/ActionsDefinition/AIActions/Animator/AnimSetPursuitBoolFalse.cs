using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/Animator/DeactivatePursuit")]
    public class AnimSetPursuitBoolFalse : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            UpdateAnimatorForStartPursuit(controller);
        }

        private void UpdateAnimatorForStartPursuit(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_Animator.SetBool("isChasing", false);

        }
    }
}
