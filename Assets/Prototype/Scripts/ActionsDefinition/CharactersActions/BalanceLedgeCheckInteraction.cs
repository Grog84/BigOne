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

        public override void Execute(CharacterStateController controller)
        {
            BalanceLedge(controller);
        }

        private void BalanceLedge(CharacterStateController controller)
        { 
            //INTERACT
            if (Input.GetButtonDown("Interact") && controller.m_CharacterController.isInJointArea && controller.m_CharacterController.isBalanceCRDone)
            {
                controller.m_CharacterController.isBalanceCRDone = false;
                #region Animator

                // IF POINT 1 IS CLOSER TO PLAYER
                if (Vector3.Distance(controller.m_CharacterController.CharacterTransform.position, controller.m_CharacterController.forwardBalance.transform.parent.GetChild(0).position)
                < Vector3.Distance(controller.m_CharacterController.CharacterTransform.position, controller.m_CharacterController.forwardBalance.transform.parent.GetChild(1).position))
                {
                    controller.m_CharacterController.m_ForwardAmount = 1f;
                }
                // IF POINT 2 IS CLOSER TO PLAYER
                else
                {
                    controller.m_CharacterController.m_ForwardAmount = -1f;
                }

                #endregion

                if (controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point1.transform.parent == controller.m_CharacterController.forwardBalance.transform.parent)
                {
                   controller.m_CharacterController.forwardBalance = controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point2;      
                }
                else
                {
                   controller.m_CharacterController.forwardBalance = controller.m_CharacterController.balanceJoint.GetComponent<BalanceJoint>().Point1;                  
                }

                controller.m_CharacterController.startBalanceLedge = true;
            }           

        }
    }
}
