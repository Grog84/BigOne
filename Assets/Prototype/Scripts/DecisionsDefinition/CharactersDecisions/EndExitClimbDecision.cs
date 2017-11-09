using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndExitClimbDecision")]
    public class EndExitClimbDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isClimbing = CheckIfEndClimbing(controller);
            return isClimbing;
        }

        private bool CheckIfEndClimbing(CharacterStateController controller)
        {

            if (!controller.m_CharacterController.startClimbAnimationEnd 
                && !controller.m_CharacterController.startClimbEnd)
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