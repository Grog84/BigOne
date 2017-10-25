using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/WalkOnStairs")]
    public class WalkOnStairs : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            WalkOnStairsSpeed(controller);
        }

        public void WalkOnStairsSpeed(CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_WalkOnStairsSpeed;
        }
    }
}
