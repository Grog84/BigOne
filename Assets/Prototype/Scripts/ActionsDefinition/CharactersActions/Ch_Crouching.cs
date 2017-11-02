using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Crouching")]
    public class Ch_Crouching : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            Crouching(controller);
        }

        public void Crouching (CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_CrouchSpeed;
        }
    }
}
