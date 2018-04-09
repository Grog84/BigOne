using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndPushPositioningDecision")]
    public class EndPushPositioningDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isPushing = CheckIfEndPushing(controller);
            return isPushing;
        }

        private bool CheckIfEndPushing(CharacterStateController controller)
        {

            if (!controller.m_CharacterController.isPushing && controller.m_CharacterController.isPushCREnd)
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
