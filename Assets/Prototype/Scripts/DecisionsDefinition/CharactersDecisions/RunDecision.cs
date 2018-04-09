using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/Run")]
    public class RunDecision : Decision
    {

        public override bool Decide(CharacterStateController controller)
        {
            if (controller.m_CharacterController.canStand && Input.GetButton("Run"))
                return true;
            else
                return false;
        }

    }
}
