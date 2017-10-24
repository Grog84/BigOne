using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetForwardPush")]
    public class AnimSetForwardPush : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            SetForwardAmount(controller);
        }

        private void SetForwardAmount(CharacterStateController controller)
        {
            if (controller.m_CharacterController.isPushLimit)
            {
                controller.m_CharacterController.m_Animator.SetFloat("Forward", Mathf.Clamp(controller.m_CharacterController.m_ForwardAmount, -1f, 0f), 0.1f, Time.deltaTime);
            }
            else if (!controller.m_CharacterController.isPushLimit)
            {
                controller.m_CharacterController.m_Animator.SetFloat("Forward", controller.m_CharacterController.m_ForwardAmount, 0.1f, Time.deltaTime);
            }

            // Debug.Log(controller.m_CharacterController.m_Animator.GetFloat("Forward"));
        }
    }
}
