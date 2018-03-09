using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StartInjured")] 
    public class StartInjured : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            StartInjuredWalk(controller);
        }

        public void StartInjuredWalk(CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_InjuredWalkSpeed;
            controller.m_CharacterController.m_Animator.SetBool("isInjured", true);
        }

    }
}
