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
                //if(QuestCarryng.Isactive)
                /*
                  return true
                 */

                /*
                 
                 */
                return false;
            }
            return false;
        }

    }
}
