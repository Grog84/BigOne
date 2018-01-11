using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/Crouch")]
    public class CrouchDecision : Decision
    {

        public override bool Decide(CharacterStateController controller)
        {

            if (Input.GetButtonDown("Crouch") && controller.m_CharacterController.Crouch == false && controller.m_CharacterController.canStand == true)
            {
                controller.m_CharacterController.Crouch = true;
            }
            else if (Input.GetButtonDown("Crouch") && controller.m_CharacterController.Crouch == true && controller.m_CharacterController.canStand == true)
            {
                controller.m_CharacterController.Crouch = false;
            }

            return controller.m_CharacterController.Crouch;

        }

    }
}
