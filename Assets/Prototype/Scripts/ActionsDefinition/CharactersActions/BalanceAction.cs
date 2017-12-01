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
        float forward;
        float backward;
        float movement;
        float angleSign = 1f;

        public override void Execute(CharacterStateController controller)
        {
            Balance(controller);
        }

        private void Balance(CharacterStateController controller)
        {
            // For Animator 
            if (Input.GetAxis("Vertical") != 0)
            {
                movement = Input.GetAxis("Vertical");
            }
            else
            {
                movement = 0;
            }

            // For actual movement
            if (Input.GetAxis("Vertical") > 0)
            {
                forward = Input.GetAxis("Vertical");
            }
            else
            {
                forward = 0;
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                backward = Input.GetAxis("Vertical");
            }
            else
            {
                backward = 0;
            }

            if (controller.m_CharacterController.forwardBalance.tag == "Board")
            {
                if (Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) <= 90)
                    angleSign = 1f;
                else
                    angleSign = -1f;

                controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward *(forward*angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);//0.0.1
                controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (backward *angleSign)* controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);//0.0.1
                
            }
            //if (controller.m_CharacterController.balanceCollider.tag == "Ledge")
            //{
               

            //}
            // Animator
            controller.m_CharacterController.m_ForwardAmount = movement;
           // Debug.Log(movement);
        }
    }
}
