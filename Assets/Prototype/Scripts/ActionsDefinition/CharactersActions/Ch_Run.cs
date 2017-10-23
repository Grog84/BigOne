using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Run")]
    public class Ch_Run : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            Run(controller);
        }

        public void Run(CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_RunSpeed;
        }

    }
}
