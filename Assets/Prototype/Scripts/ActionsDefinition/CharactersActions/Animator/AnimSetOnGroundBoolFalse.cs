using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/DeactivateNormal")]
    public class AnimSetOnGroundBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForGround(controller);
        }

        private void UpdateAnimatorForGround(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("OnGround", false);
        }
    }
}