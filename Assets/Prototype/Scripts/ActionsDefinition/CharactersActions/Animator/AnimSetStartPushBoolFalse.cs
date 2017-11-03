using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/DeactivateStartPush")]
    public class AnimSetStartPushBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForStartPush(controller);
        }

        private void UpdateAnimatorForStartPush(CharacterStateController controller)
        {
            controller.m_CharacterController.m_ForwardAmount = 0;
            controller.m_CharacterController.m_Animator.SetFloat("Forward", 0f);
            controller.m_CharacterController.m_Animator.SetBool("isStartingPush", false);
            // Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isStartingPush"));
        }
    }
}
