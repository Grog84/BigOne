using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivateClimb")]
    public class AnimSetClimbBoolTrue : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForClimb(controller);
        }

        private void UpdateAnimatorForClimb(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isClimbing", true);
            // Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isClimbing"));
        }
    }
}
