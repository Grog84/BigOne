using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateStartClimb")]
    public class AnimSetStartClimbBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForClimb(controller);
        }

        private void UpdateAnimatorForClimb(CharacterStateController controller)
        {
            // if (controller.m_CharacterController.climbingTop)
            // {
            controller.m_CharacterController.m_Animator.SetBool("isStartClimb", false);
            // }

        }
    }
}