using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivateFall")]
    public class AnimSetFallBoolTrue : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForFall(controller);
        }

        private void UpdateAnimatorForFall(CharacterStateController controller)
        {

            controller.m_CharacterController.m_Animator.SetBool("isFalling", true);


        }
    }
}
