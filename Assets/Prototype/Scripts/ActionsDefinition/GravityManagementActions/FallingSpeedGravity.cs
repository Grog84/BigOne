using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/FallingSpeedGravity")]
    public class FallingSpeedGravity : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            FallingGravity(controller);
        }

        public void FallingGravity(CharacterStateController controller)
        {
            controller.characterStats.m_Gravity = controller.characterStats.m_FallGravity;
        }

    }
}
