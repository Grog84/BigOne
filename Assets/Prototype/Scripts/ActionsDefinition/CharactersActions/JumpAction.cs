using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Jump")]
    public class JumpAction : _Action
    {
        Vector3 m_Velocity;

        public override void Execute(CharacterStateController controller)
        {
            Jump(controller);
        }

        private void Jump(CharacterStateController controller)
        {
            bool m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

            if (m_Jump)
            {
                m_Velocity = controller.m_CharacterController.m_CharController.velocity;
                m_Velocity.y += Mathf.Sqrt(controller.characterStats.m_JumpHeight * -2f * controller.characterStats.m_Gravity);
            }
        }
    }
}
