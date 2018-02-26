using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using QuestManager;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/Carry")]
    public class CarryingDecision : Decision
    {
        
        public override bool Decide(CharacterStateController controller)
        {
            if (controller.m_CharacterController.hasInteractedWithNPC)
            {
                //Debug.Log(GMController.instance.m_QM.name);
                //foreach (Quest quest in GMController.instance.m_QM.QC.QuestList)
                //{
                //    if (quest.questType == QUESTTYPE.CONSEGNA_OGGETTO && quest.active && !quest.turnInStatus)
                //    {
                //        Debug.Log(quest.active);
                //        controller.m_CharacterController.hasInteractedWithNPC = false;
                //        controller.m_CharacterController.currentConsegnaOggetto = GMController.instance.m_QM.QC.QuestList.IndexOf(quest);
                //        return true;
                //    }
                //}

                return false;
            }
            return false;
        }

    }
}
