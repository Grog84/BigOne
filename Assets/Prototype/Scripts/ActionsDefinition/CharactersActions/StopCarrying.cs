using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StopCarrying")] 
    public class StopCarrying : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            StartCarryingItem(controller);
        }

        public void StartCarryingItem(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isCarryingItem", false);
        }

    }
}
