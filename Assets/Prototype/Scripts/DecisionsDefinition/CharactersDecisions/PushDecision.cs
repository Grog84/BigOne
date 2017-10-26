using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/PushDecision")]
    public class PushDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isPushing = CheckIfPushing(controller);
            return isPushing;
        }

        private bool CheckIfPushing(CharacterStateController controller)
        {
            if (controller.m_CharacterController.isInPushArea && controller.m_CharacterController.isPushDirectionRight && Input.GetButtonDown("Interact"))
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
