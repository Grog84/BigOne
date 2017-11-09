using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndClimbFallDecision")]
    public class EndClimbFallDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isClimbing = CheckIfClimbingFall(controller);
            return isClimbing;
        }

        private bool CheckIfClimbingFall(CharacterStateController controller)
        {
            if (/*!controller.m_CharacterController.climbingTop && */Input.GetButtonDown("Cancel"))
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