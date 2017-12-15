using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/StartClimbPositioningDecision")]
    public class StartClimbPositioningDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isPushing = CheckIfEndPushing(controller);
            return isPushing;
        }

        private bool CheckIfEndPushing(CharacterStateController controller)
        {

            if (controller.m_CharacterController.isBottomClimbCRDone && controller.m_CharacterController.isClimbCRDone)
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
