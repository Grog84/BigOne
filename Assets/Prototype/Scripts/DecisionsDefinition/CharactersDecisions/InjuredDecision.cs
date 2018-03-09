using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using QuestManager;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/Injured")]
    public class InjuredDecision : Decision
    {
        
        public override bool Decide(CharacterStateController controller)
        {
            if (controller.m_CharacterController.isInjured)
            {
                
                return true;
            }
            return false;
        }

    }
}
