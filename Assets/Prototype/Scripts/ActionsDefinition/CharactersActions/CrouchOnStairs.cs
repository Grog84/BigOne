using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/CrouchOnStairs")]
    public class CrouchOnStairs : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            CrouchOnStairsSpeed(controller);
        }

        public void CrouchOnStairsSpeed(CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_CrouchOnStarisSpeed;
        }

    }
}
