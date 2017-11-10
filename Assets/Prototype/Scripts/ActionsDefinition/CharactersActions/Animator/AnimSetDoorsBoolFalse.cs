using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/DeactivateDoors")]
    public class AnimSetDoorsBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForDoors(controller);
        }

        private void UpdateAnimatorForDoors(CharacterStateController controller)
        {
            controller.m_CharacterController.m_ForwardAmount = 0;
            controller.m_CharacterController.m_Animator.SetFloat("Forward", 0f);

            if (!controller.m_CharacterController.startDoorAction)
            {
                controller.m_CharacterController.m_Animator.SetBool("isOpening", false);
            }

            if (controller.m_CharacterController.isDoorRotate && controller.m_CharacterController.isEndAnim)
            {
                controller.m_CharacterController.isEndDoorAction = false;
            }
        }
    }
}