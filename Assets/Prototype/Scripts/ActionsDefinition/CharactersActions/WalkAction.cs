using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Walk")]
    public class WalkAction : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            Walk(controller);
        }

        public void Walk(CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_WalkSpeed;
        }

    }
}
