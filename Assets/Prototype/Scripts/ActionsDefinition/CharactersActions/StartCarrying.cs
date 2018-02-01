﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StartCarrying")] 
    public class StartCarrying : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            StartCarryingItem(controller);
        }

        public void StartCarryingItem(CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_CarryingItemSpeed;
            controller.m_CharacterController.m_Animator.SetBool("isCarryingItem", true);
        }

    }
}
