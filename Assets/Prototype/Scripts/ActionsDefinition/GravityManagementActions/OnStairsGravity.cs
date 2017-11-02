using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/OnStairsGravity")]
    public class OnStairsGravity : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            onStairsGravity(controller);
        }

        public void onStairsGravity(CharacterStateController controller)
        {
            controller.characterStats.m_Gravity = controller.characterStats.m_StairsGravity;
        }
    }
}
