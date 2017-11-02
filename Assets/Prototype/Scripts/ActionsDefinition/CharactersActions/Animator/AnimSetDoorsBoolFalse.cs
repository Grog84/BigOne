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
            controller.m_CharacterController.m_Animator.SetBool("isOpening", false);
        }
    }
}