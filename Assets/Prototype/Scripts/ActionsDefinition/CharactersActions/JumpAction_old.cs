using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Jump")]
    public class JumpAction_old : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            Jump(controller);
        }

        private void Jump(CharacterStateController controller)
        {
            bool m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

            if (m_Jump)
            {
                // jump!
                controller.m_CharacterController.m_Rigidbody.velocity = new Vector3(controller.m_CharacterController.m_Rigidbody.velocity.x,
                    controller.characterStats.m_JumpPower, controller.m_CharacterController.m_Rigidbody.velocity.z);
                controller.characterStats.m_GroundCheckDistance = 0.1f;
            }
        }
    }
}