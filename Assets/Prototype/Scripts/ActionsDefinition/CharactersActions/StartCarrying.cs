using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StartCarrying")] 
    public class CrouchOnStairs : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            StartCarrying(controller);
        }

        public void StartCarrying(CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_CrouchOnStarisSpeed;
            controller.m_CharacterController.m_Animator.SetBool("isCarryingItem", true);
        }

    }
}
