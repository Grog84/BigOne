using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivateCrouch")]
    public class AnimSetCrouchBoolTrue : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForCrouch(controller);
        }

        private void UpdateAnimatorForCrouch(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("Crouch", true);
        }
    }
}
