using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Crouch")]
    public class CrouchAction : _Action
    {

        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private Vector3 m_GroundNormal;

        public override void Execute(CharacterStateController controller)
        {
            Crouch(controller);
        }

        private void Crouch(CharacterStateController controller)
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            // calculate move direction to pass to character
            if (controller.m_CharacterController.m_Camera != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(controller.m_CharacterController.m_Camera.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * controller.m_CharacterController.m_Camera.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }

            // convert the world relative moveInput vector into a local-relative
            // turn amount and forward amount required to head in the desired
            // direction.
            if (m_Move.magnitude > 1f) m_Move.Normalize();
            m_Move = controller.m_CharacterController.CharacterTansform.InverseTransformDirection(m_Move);
            m_Move = Vector3.ProjectOnPlane(m_Move, m_GroundNormal);
            controller.m_CharacterController.m_TurnAmount = Mathf.Atan2(m_Move.x, m_Move.z);
            controller.m_CharacterController.m_ForwardAmount = m_Move.z;
        }

        public void Move(Vector3 move, CharacterStateController controller)
        {

            // convert the world relative moveInput vector into a local-relative
            // turn amount and forward amount required to head in the desired
            // direction.
            if (move.magnitude > 1f) move.Normalize();
            move = controller.m_CharacterController.CharacterTansform.InverseTransformDirection(move);
            move = Vector3.ProjectOnPlane(move, m_GroundNormal);
            controller.m_CharacterController.m_TurnAmount = Mathf.Atan2(move.x, move.z);
            controller.m_CharacterController.m_ForwardAmount = move.z;

            ApplyExtraTurnRotation(controller);
            //ScaleCapsuleForCrouching(crouch);

        }

        void ApplyExtraTurnRotation(CharacterStateController controller)
        {
            // help the character turn faster (this is in addition to root rotation in the animation)
            float turnSpeed = Mathf.Lerp(controller.characterStats.m_StationaryTurnSpeed,
                controller.characterStats.m_MovingTurnSpeed, controller.m_CharacterController.m_ForwardAmount);
            controller.m_CharacterController.CharacterTansform.Rotate(0, controller.m_CharacterController.m_TurnAmount * turnSpeed * Time.deltaTime, 0);
        }


    }
}
