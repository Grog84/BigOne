using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/BalanceLedge")]
    public class BalanceLedgeAction: _Action
    {
        float movement;
        float angleSign = 1f;

        public override void Execute(CharacterStateController controller)
        {
            BalanceLedge(controller);
        }

        private void BalanceLedge(CharacterStateController controller)
        {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    movement = Input.GetAxis("Horizontal");
                }
                else
                {
                    movement = 0;
                }

                if (Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) <= 45)
                    angleSign = -1f;
                else
                    angleSign = 1f;
               

               
                if (controller.m_CharacterController.forwardBalance.name == "Point1")
                {
                    controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (movement * angleSign * -1) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);                 
                }
                else
                {
                    controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (movement * angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
                }

               if (Input.GetButtonDown("Interact") && controller.m_CharacterController.isInJointArea)
               {
                    if(controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point1.transform.parent == controller.m_CharacterController.forwardBalance.transform.parent)
                    {
                        controller.m_CharacterController.forwardBalance = controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point2;
                        controller.m_CharacterController.startBalanceLedge = true;

                    }
                    else
                    {
                        controller.m_CharacterController.forwardBalance = controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point1;
                        controller.m_CharacterController.startBalanceLedge = true;
                    }
               }
            

            // Animator
            controller.m_CharacterController.m_ForwardAmount = movement * angleSign;

        }
    }
}
