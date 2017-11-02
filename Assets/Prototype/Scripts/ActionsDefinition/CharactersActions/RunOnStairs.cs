using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/RunOnStairs")]
    public class RunOnStairs : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            RunOnStairsSpeed(controller);
        }

        public void RunOnStairsSpeed(CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_RunOnStarisSpeed;
        }

    }
}
