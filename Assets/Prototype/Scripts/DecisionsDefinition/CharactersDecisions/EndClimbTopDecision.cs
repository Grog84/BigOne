using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndClimbTopDecision")]
    public class EndClimbTopDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isClimbing = CheckIfClimbingTop(controller);
            return isClimbing;
        }

        private bool CheckIfClimbingTop(CharacterStateController controller)
        {
            if (controller.m_CharacterController.climbingTop && Input.GetButtonDown("Interact"))
            {

                //Debug.Log("pereppe");
                return true;


            }
            else
            {
                return false;
            }

        }


    }
}
