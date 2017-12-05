using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/EndBalanceBoardAction")]
    public class EndBalanceBoardAction : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            EndBalance(controller);
        }

        private void EndBalance(CharacterStateController controller)
        {
            controller.m_CharacterController.isInDanger = false;
            controller.m_CharacterController.m_Animator.SetBool("onBoard", false);
            controller.m_CharacterController.m_ForwardAmount = 0;
        }

    }
}
