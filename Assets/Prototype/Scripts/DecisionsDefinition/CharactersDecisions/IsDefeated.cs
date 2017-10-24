using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/IsDefeated")]
    public class IsDefeated : Decision
    {

        public override bool Decide(CharacterStateController controller)
        {
            return controller.m_CharacterController.isDefeated;
        }
    }
}
