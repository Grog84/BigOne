using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndDoorInteractionDecision")]
    public class EndDoorInteractionDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isInteracting = CheckIfEndDoorInteraction(controller);
            return isInteracting;
        }

        private bool CheckIfEndDoorInteraction(CharacterStateController controller)
        {

            if (!controller.m_CharacterController.startDoorAnimation)
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
