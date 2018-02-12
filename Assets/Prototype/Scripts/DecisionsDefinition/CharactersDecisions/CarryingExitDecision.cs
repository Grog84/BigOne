using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using QuestManager;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/CarryingExit")]
    public class CarryingExitDecision : Decision
    {

        public override bool Decide(CharacterStateController controller)
        {
            if (controller.m_CharacterController.hasInteractedWithNPC)
            {
                if (GMController.instance.m_QM.QC.QuestList[controller.m_CharacterController.currentConsegnaOggetto].turnInStatus)
                {                
                    controller.m_CharacterController.hasInteractedWithNPC = false;                
                    return true;
                }
                return false;
            }
            return false;
        }

    }
}
