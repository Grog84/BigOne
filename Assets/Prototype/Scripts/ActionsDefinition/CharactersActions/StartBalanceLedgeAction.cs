using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StartBalanceLedgeAction")]
    public class StartBalanceLedgeAction : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            StartBalance(controller);
        }

        private void StartBalance(CharacterStateController controller)
        {
            controller.m_CharacterController.isInDanger= true;

            if (Vector3.Distance(controller.m_CharacterController.CharacterTransform.position, controller.m_CharacterController.balanceCollider.transform.GetChild(0).position)
               < Vector3.Distance(controller.m_CharacterController.CharacterTransform.position, controller.m_CharacterController.balanceCollider.transform.GetChild(1).position))
            {
                controller.m_CharacterController.forwardBalance = controller.m_CharacterController.balanceCollider.transform.GetChild(0).gameObject;
            }
            else
            {
                controller.m_CharacterController.forwardBalance = controller.m_CharacterController.balanceCollider.transform.GetChild(1).gameObject;
            }

            controller.m_CharacterController.m_Animator.SetBool("onLedge", true);
            controller.m_CharacterController.startBalanceLedge = true;
            controller.m_CharacterController.animSpeed = controller.m_CharacterController.m_Animator.speed;

        }

    }
}
