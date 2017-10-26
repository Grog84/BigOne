using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/SetForwardToZero")]
    public class AnimSetForwardToZero : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            SetForward(controller);
        }

        private void SetForward(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetFloat("Forward", 0f);
        }
    }
}
