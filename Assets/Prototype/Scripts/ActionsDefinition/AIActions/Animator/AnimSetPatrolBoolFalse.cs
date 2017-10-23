using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/Animator/DeactivatePatrol")]
    public class AnimSetPatrolBoolFalse : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            UpdateAnimatorForStartPatrol(controller);
        }

        private void UpdateAnimatorForStartPatrol(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_Animator.SetBool("isPatrolling", false);

        }
    }
}