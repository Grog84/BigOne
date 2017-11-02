using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/ActivateExitPush")]
    public class AnimSetExitPushBoolTrue : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForStartPush(controller);
        }

        private void UpdateAnimatorForStartPush(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isStartingPush", false);
            Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isStartingPush"));
        }
    }
}
