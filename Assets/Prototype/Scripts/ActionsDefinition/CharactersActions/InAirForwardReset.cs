using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/InAirForwardReset")]
    public class InAirForwardReset : _Action
    {

        Vector3 m_Velocity;

        public override void Execute(CharacterStateController controller)
        {
            AirbornMovementReset(controller);
        }

        private void AirbornMovementReset(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetFloat("Forward", 0f);
        }
    }
}
