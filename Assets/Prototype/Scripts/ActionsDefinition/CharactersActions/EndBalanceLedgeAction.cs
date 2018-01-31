using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/EndBalanceLedgeAction")]
    public class EndBalanceLedgeAction : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            EndBalance(controller);
        }

        private void EndBalance(CharacterStateController controller)
        {
            if (!Input.GetButtonDown("Pause"))
            {
                controller.m_CharacterController.m_Animator.speed = controller.m_CharacterController.animSpeed;
                controller.m_CharacterController.ledgeForwardActive = true;
                controller.m_CharacterController.ledgeBackwardActive = true;
                controller.m_CharacterController.isInDanger = false;
                controller.m_CharacterController.m_Animator.SetBool("onLedge", false);
                controller.m_CharacterController.m_ForwardAmount = 0;
            }

        }

    }
}
