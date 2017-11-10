using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/DeactivateClimb")]
    public class AnimSetClimbBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForClimb(controller);
        }

        private void UpdateAnimatorForClimb(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isClimbing", false);
            controller.m_CharacterController.secureFall = false;
        }
    }
}
