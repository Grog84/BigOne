using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivateStartPush")]
    public class AnimSetStartPushBoolTrue : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForStartPush(controller);
        }

        private void UpdateAnimatorForStartPush(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isStartingPush", true);
            Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isStartingPush"));
        }
    }
}
