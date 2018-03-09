using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using QuestManager;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/InjuredExit")]
    public class InjuredExitDecision : Decision
    {

        public override bool Decide(CharacterStateController controller)
        {
            if (controller.m_CharacterController.isInjured == false)
            {
                
                return true;
            }
            return false;
        }

    }
}
