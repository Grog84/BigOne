using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateCrouch")]
    public class AnimSetCrouchBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForCrouch(controller);
        }

        private void UpdateAnimatorForCrouch(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("Crouch", false);
        }
    }
}
