using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/BalanceLedgeCheck")]
    public class BalanceLedgeCheckAction: _Action
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
            // START IN POINT 1
            if (controller.m_CharacterController.forwardBalance.name == "Point1")
            {
               if (controller.m_CharacterController.isLedgeLimit)
               {
                  Vector3 validDir = controller.m_CharacterController.CharacterTransform.position - controller.m_CharacterController.balanceJoint.transform.position;

                  if (Vector3.Angle(controller.m_CharacterController.forwardBalance.transform.forward, validDir) > 90)
                  {
                      controller.m_CharacterController.ledgeForwardActive = true;
                      controller.m_CharacterController.ledgeBackwardActive = false;
                  }
                  else if (Vector3.Angle(controller.m_CharacterController.forwardBalance.transform.forward, validDir) < 90)
                  {
                      controller.m_CharacterController.ledgeForwardActive = false;
                      controller.m_CharacterController.ledgeBackwardActive = true;
                  }
                     
               }
               else if(!controller.m_CharacterController.isLedgeLimit)
               {
                   controller.m_CharacterController.ledgeForwardActive = true;
                   controller.m_CharacterController.ledgeBackwardActive = true;
               }
              
            } 

            // START IN POINT 2
            else
            {
               if (controller.m_CharacterController.isLedgeLimit)
               {
                   Vector3 validDir = controller.m_CharacterController.CharacterTransform.position - controller.m_CharacterController.balanceJoint.transform.position;

                   if(Vector3.Angle(controller.m_CharacterController.forwardBalance.transform.forward, validDir ) > 90)
                   {
                       controller.m_CharacterController.ledgeForwardActive = false;
                       controller.m_CharacterController.ledgeBackwardActive = true;
                   }
                   else if(Vector3.Angle(controller.m_CharacterController.forwardBalance.transform.forward, validDir) < 90)
                   {
                       controller.m_CharacterController.ledgeForwardActive = true;
                       controller.m_CharacterController.ledgeBackwardActive = false;
                   }


               }
               else if (!controller.m_CharacterController.isLedgeLimit)
               {
                   controller.m_CharacterController.ledgeForwardActive = true;
                   controller.m_CharacterController.ledgeBackwardActive = true;
               }

            }

        }
    }
}
