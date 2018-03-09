using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StopInjured")] 
    public class StopInjured : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            StartInjuredWalk(controller);
        }

        public void StartInjuredWalk(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isInjured", false);
        }

    }
}
