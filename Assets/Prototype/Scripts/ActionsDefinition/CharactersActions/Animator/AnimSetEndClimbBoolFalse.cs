using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/DeactivateEndClimb")]
    public class AnimSetEndClimbBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForClimb(controller);
        }

        private void UpdateAnimatorForClimb(CharacterStateController controller)
        {
        
            controller.m_CharacterController.m_ForwardAmount = 0;
            controller.m_CharacterController.m_Animator.SetFloat("Forward", 0f);


            if (!controller.m_CharacterController.startClimbAnimationEnd)
            {
                controller.m_CharacterController.m_Animator.SetBool("isEndClimb", false);
            }
         
         
        }
    }
}