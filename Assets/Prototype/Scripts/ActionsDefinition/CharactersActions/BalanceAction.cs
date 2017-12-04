using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Balance")]
    public class BalanceAction : _Action
    {
        Vector3 m_Move;
        float movement;
        float angleSign = 1f;

        public override void Execute(CharacterStateController controller)
        {
            Balance(controller);
        }

        private void Balance(CharacterStateController controller)
        {

           
                if (Input.GetAxis("Vertical") != 0)
                {
                    movement = Input.GetAxis("Vertical");
                }
                else
                {
                    movement = 0;
                }

            if (controller.m_CharacterController.forwardBalance.tag == "Board")
            {
                if (Input.GetAxis("Vertical") != 0)
                {
                    movement = Input.GetAxis("Vertical");
                }
                else
                {
                    movement = 0;
                }

                if (Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) <= 90)
                    angleSign = 1f;
                else
                    angleSign = -1f;

                 controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward *(movement*angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
                
            }
            else if (controller.m_CharacterController.forwardBalance.tag == "Ledge")
            {

                if (Input.GetAxis("Horizontal") != 0)
                {
                    movement = Input.GetAxis("Horizontal");
                }
                else
                {
                    movement = 0;
                }

                if (Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) <= 90)
                    angleSign = -1f;
                else
                    angleSign = 1f;

                controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (movement * angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
            }

            // Animator
            controller.m_CharacterController.m_ForwardAmount = movement *angleSign;

        }
    }
}
