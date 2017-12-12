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
            if ((controller.m_CharacterController.m_ForwardAmount == 1 || controller.m_CharacterController.m_ForwardAmount == -1) && controller.m_CharacterController.isInJointArea && controller.m_CharacterController.isBalanceCRDone)
            {
                controller.m_CharacterController.isBalanceCRDone = false;
               
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
