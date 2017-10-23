using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateStartPush")]
    public class AnimSetStartPushBoolFalse : _Action
    {

<<<<<<< HEAD
        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForStartPush(controller);
        }

        private void UpdateAnimatorForStartPush(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isStartingPush", false);
            // Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isStartingPush"));
        }
=======
    private void UpdateAnimatorForStartPush(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetBool("isStartingPush", false);
        Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isStartingPush"));
>>>>>>> f33a8f5
    }
}
