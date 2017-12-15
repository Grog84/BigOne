using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/ExitBalanceDecisionCrouch")]
    public class ExitBalanceDecisionCrouch : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isInBalance = CheckIfEndBalance(controller);
            return isInBalance;
        }

        private bool CheckIfEndBalance(CharacterStateController controller)
        {

            if (!controller.m_CharacterController.isInBalanceArea && !controller.m_CharacterController.m_Animator.GetBool("isWalking"))
            {

                return true;


            }
            else
            {
                return false;
            }


        }


    }
}