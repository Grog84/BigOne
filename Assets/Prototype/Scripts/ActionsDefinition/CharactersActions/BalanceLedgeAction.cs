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
        float forward;
        float backward;

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


            if (Input.GetAxis("Horizontal") > 0)
            {
                forward = Input.GetAxis("Horizontal");
            }
            else
            {
                forward = 0;
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                backward = Input.GetAxis("Horizontal");
                //controller.m_CharacterController.isLedgeLimit = false;
            }
            else
            {
                backward = 0;
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                backward = 0;
                forward = 0;
                movement = 0;
            }
            
            // START IN POINT 1
            if (controller.m_CharacterController.forwardBalance.name == "Point1")
            {
               //if (controller.m_CharacterController.isLedgeLimit)
               //{
               //   Vector3 validDir = controller.m_CharacterController.CharacterTransform.position - controller.m_CharacterController.balanceJoint.transform.position;

               //   if (Vector3.Angle(controller.m_CharacterController.forwardBalance.transform.forward, validDir) > 90)
               //   {
               //       controller.m_CharacterController.ledgeForwardActive = true;
               //       controller.m_CharacterController.ledgeBackwardActive = false;
               //   }
               //   else if (Vector3.Angle(controller.m_CharacterController.forwardBalance.transform.forward, validDir) < 90)
               //   {
               //       controller.m_CharacterController.ledgeForwardActive = false;
               //       controller.m_CharacterController.ledgeBackwardActive = true;
               //   }
                     
               //}
               //else if(!controller.m_CharacterController.isLedgeLimit)
               //{
               //    controller.m_CharacterController.ledgeForwardActive = true;
               //    controller.m_CharacterController.ledgeBackwardActive = true;
               //}

               if (controller.m_CharacterController.ledgeForwardActive && !controller.m_CharacterController.ledgeBackwardActive)
               {
                   controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (forward * angleSign * -1) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
               }
               else if (controller.m_CharacterController.ledgeBackwardActive && !controller.m_CharacterController.ledgeForwardActive)
               {
                   controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (backward * angleSign * -1) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
               }
               else
               {
                   controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (backward * angleSign * -1) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
                   controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (forward * angleSign * -1) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
               }
              
            } 

            // START IN POINT 2
            else
            {
               //if (controller.m_CharacterController.isLedgeLimit)
               //{
               //    Vector3 validDir = controller.m_CharacterController.CharacterTransform.position - controller.m_CharacterController.balanceJoint.transform.position;

               //    if(Vector3.Angle(controller.m_CharacterController.forwardBalance.transform.forward, validDir ) > 90)
               //    {
               //        controller.m_CharacterController.ledgeForwardActive = false;
               //        controller.m_CharacterController.ledgeBackwardActive = true;
               //    }
               //    else if(Vector3.Angle(controller.m_CharacterController.forwardBalance.transform.forward, validDir) < 90)
               //    {
               //        controller.m_CharacterController.ledgeForwardActive = true;
               //        controller.m_CharacterController.ledgeBackwardActive = false;
               //    }


               //}
               //else if (!controller.m_CharacterController.isLedgeLimit)
               //{
               //    controller.m_CharacterController.ledgeForwardActive = true;
               //    controller.m_CharacterController.ledgeBackwardActive = true;
               //}

               if(controller.m_CharacterController.ledgeForwardActive && !controller.m_CharacterController.ledgeBackwardActive)
               {
                  controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (forward * angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
               }
               else if(controller.m_CharacterController.ledgeBackwardActive && !controller.m_CharacterController.ledgeForwardActive)
               {
                  controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (backward * angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
               }
               else
               {
                  controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (backward * angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
                  controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward * (forward * angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);
               }

            }
              
            //    //INTERACT
            //   if (Input.GetButtonDown("Interact") && controller.m_CharacterController.isInJointArea)
            //   {
            //        if(controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point1.transform.parent == controller.m_CharacterController.forwardBalance.transform.parent)
            //        {
            //            controller.m_CharacterController.forwardBalance = controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point2;
            //            controller.m_CharacterController.startBalanceLedge = true;

            //        }
            //        else
            //        {
            //            controller.m_CharacterController.forwardBalance = controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point1;
            //            controller.m_CharacterController.startBalanceLedge = true;
            //        }
            //   }
            //Debug.Log("Forward = " + forward + " Backward = " + backward);

            // Animator
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
    }
}
