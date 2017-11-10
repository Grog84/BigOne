using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/DeactivateLockedDoors")]
    public class AnimSetDoorsLockedBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForDoors(controller);
        }

        private void UpdateAnimatorForDoors(CharacterStateController controller)
        {
            controller.m_CharacterController.m_ForwardAmount = 0;
            controller.m_CharacterController.m_Animator.SetFloat("Forward", 0f);

            controller.m_CharacterController.m_Animator.SetBool("isLocked", false);
            controller.m_CharacterController.isEndAnim = false;



        }
    }
}