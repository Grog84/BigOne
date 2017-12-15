using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/ActivateDefeat")]
    public class AnimSetDefeatTrue : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForDefeat(controller);
        }

        private void UpdateAnimatorForDefeat(CharacterStateController controller)
        {
            Debug.Log("Action animator dead");
            controller.m_CharacterController.m_Animator.SetBool("isDead", true);
            Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isDead"));
        }

    }
}
