using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndItemCollectDecision")]
    public class EndItemCollectDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isInteracting = CheckIfEndDoorInteraction(controller);
            return isInteracting;
        }

        private bool CheckIfEndDoorInteraction(CharacterStateController controller)
        {

            if (!controller.m_CharacterController.startItemAnimation)
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
