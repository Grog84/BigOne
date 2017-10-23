using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/OverWritableGravity")]
    public class OverWritableGravity : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            OverWriteGravity(controller);
        }

        public void OverWriteGravity(CharacterStateController controller)
        {
            controller.characterStats.m_Gravity = controller.characterStats.m_DefaultGravity;
        }
    }
}