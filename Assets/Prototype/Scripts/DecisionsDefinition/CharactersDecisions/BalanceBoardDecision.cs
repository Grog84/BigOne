using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/BalanceBoardDecision")]
    public class BalanceBoardDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isInBalance = CheckIfInBalance(controller);
            return isInBalance;
        }

        private bool CheckIfInBalance(CharacterStateController controller)
        {
            if (controller.m_CharacterController.isInBalanceArea && controller.m_CharacterController.balanceCollider.tag =="Board")
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
