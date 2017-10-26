﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/DoorsInteractionDecision")]
    public class DoorsInteractionDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isInteracting = CheckIfDoorsInteract(controller);
            return isInteracting;
        }

        private bool CheckIfDoorsInteract(CharacterStateController controller)
        {
            if (controller.m_CharacterController.isInDoorArea && controller.m_CharacterController.isDoorDirectionRight && Input.GetButtonDown("Interact"))
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
