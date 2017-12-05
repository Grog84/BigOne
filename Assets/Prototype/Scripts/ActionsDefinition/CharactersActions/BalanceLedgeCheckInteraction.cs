using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/BalanceLedgeCheckInteraction")]
    public class BalanceLedgeCheckInteraction: _Action
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
             
            //INTERACT
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
            Debug.Log("Forward = " + forward + " Backward = " + backward);

        }
    }
}
