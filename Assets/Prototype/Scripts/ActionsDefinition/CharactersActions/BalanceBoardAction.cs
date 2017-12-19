using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/BalanceBoard")]
    public class BalanceBoardAction : _Action
    {
        float movement;
        float angleSign = 1f;

        public override void Execute(CharacterStateController controller)
        {
            Balance(controller);
        }

        private void Balance(CharacterStateController controller)
        {
            #region Movemets and Angles

            // ANGLE FOR INPUT
            if (Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) < 45 ||
                Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) >= 135)
            {
                if (Input.GetAxis("Vertical") != 0)
                {
                    movement = Input.GetAxis("Vertical");
                }
                else
                {
                    movement = 0;
                }
            }
            else 
            if(Vector3.Angle(controller.m_CharacterController.CharacterTransform.right, controller.m_CharacterController.m_Camera.forward) < 45 ||
               Vector3.Angle(controller.m_CharacterController.CharacterTransform.right, controller.m_CharacterController.m_Camera.forward) >= 135)
            {
               if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
               {
                  if (Mathf.Abs(Input.GetAxis("Horizontal")) >= Mathf.Abs(Input.GetAxis("Vertical")))
                  {
                     movement = Input.GetAxis("Horizontal");
                  }
                  else
                  {
                       if (Vector3.Angle(controller.m_CharacterController.CharacterTransform.right, controller.m_CharacterController.m_Camera.forward) >= 135)
                       {
                            movement = Input.GetAxis("Vertical");
                       }
                       else
                       if(Vector3.Angle(controller.m_CharacterController.CharacterTransform.right, controller.m_CharacterController.m_Camera.forward) <= 45)
                       {
                            movement = (Input.GetAxis("Vertical")) * -1;
                       }
                  }
               }
               else
               {
                  movement = 0;
               }
            }
            // ANGLE FOR SIGN
            if (Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) <= 135 &&
                Vector3.Angle(controller.m_CharacterController.CharacterTransform.right, controller.m_CharacterController.m_Camera.forward) >= 45)
            {
                angleSign = 1f;
            }
            else
            {
                angleSign = -1f;
            }

            //TRANSFORM MOVEMENT
            //controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward *(movement*angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
#endregion     

            // Debug.Log("Forward: " + Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) + " Right: " + Vector3.Angle(controller.m_CharacterController.CharacterTransform.right, controller.m_CharacterController.m_Camera.forward));

            #region Animator

            // Assign m_ForwardAmount value except when in coroutine
            if (controller.m_CharacterController.isBalanceCRDone)
            {
                controller.m_CharacterController.m_ForwardAmount = movement * angleSign;

                if (movement == 0)
                {
                    controller.m_CharacterController.m_Animator.speed = 0;
                }
                else
                {
                    controller.m_CharacterController.m_Animator.speed = controller.m_CharacterController.animSpeed;
                }
            }
#endregion
        }
    }
}
