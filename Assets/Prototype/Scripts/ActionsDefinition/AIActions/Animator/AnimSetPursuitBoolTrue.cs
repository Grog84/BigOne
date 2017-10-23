using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/Animator/ActivatePursuit")]
    public class AnimSetpursuitBoolTrue : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            UpdateAnimatorForStartPursuit(controller);
        }

        private void UpdateAnimatorForStartPursuit(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_Animator.SetBool("isChasing", true);

        }
    }
}
