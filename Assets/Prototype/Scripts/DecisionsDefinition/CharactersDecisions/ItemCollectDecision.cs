using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/ItemCollectDecision")]
    public class ItemCollectDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isInteracting = CheckIfItemCollect(controller);
            return isInteracting;
        }

        private bool CheckIfItemCollect(CharacterStateController controller)
        {
            if (controller.m_CharacterController.isInKeyArea && Input.GetButtonDown("Interact"))
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
