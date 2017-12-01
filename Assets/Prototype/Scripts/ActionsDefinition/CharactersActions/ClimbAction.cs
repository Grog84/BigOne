using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Climb")]
    public class ClimbAction : _Action
    {
        Vector3 m_Move;
        float up;
        float down;
        float movement;

        public override void Execute(CharacterStateController controller)
        {
            Climb(controller);
        }

        private void Climb(CharacterStateController controller)
        {
            // For Animator 
            if (Input.GetAxis("Vertical") != 0)
            {
                movement = Input.GetAxis("Vertical");
            }
            else
            {
                movement = 0;
            }

            // For actual movement
            if (Input.GetAxis("Vertical") > 0)
            {
                up = Input.GetAxis("Vertical");
            }
            else
            {
                up = 0;
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                down = Input.GetAxis("Vertical");
            }
            else
            {
                down = 0;
            }

            if (!controller.m_CharacterController.climbingTop)
            {
                controller.m_CharacterController.CharacterTransform.Translate(Vector3.up * up * controller.characterStats.m_ClimbSpeed * Time.deltaTime);//0.0.1

            }
            if (!controller.m_CharacterController.climbingBottom)
            {
                controller.m_CharacterController.CharacterTransform.Translate(Vector3.up * down * controller.characterStats.m_ClimbSpeed * Time.deltaTime);//0.0.1

            }
            // Animator
            controller.m_CharacterController.m_ForwardAmount = movement;

            RaycastHit hit;

            if (Physics.Raycast(controller.m_CharacterController.CharacterTransform.position, Vector3.down, out hit, controller.m_CharacterController.m_CharStats.m_ClimbFallHeight))
            {
                Debug.DrawRay(controller.m_CharacterController.CharacterTransform.position, Vector3.down, Color.red);

                if (!(hit.transform.gameObject.layer == LayerMask.NameToLayer("Player")))
                {
                    controller.m_CharacterController.secureFall = true;
                    controller.m_CharacterController.isInDanger = false;
                    controller.m_CharacterController.ShowCancelIcon();
                    controller.m_CharacterController.ShowStopClimbIcon();
                    controller.m_CharacterController.RotateCanvas();
                }
            }
            else
            {
                controller.m_CharacterController.secureFall = false;
                controller.m_CharacterController.isInDanger = true;
                controller.m_CharacterController.ShowDisabledCancelIcon();
                controller.m_CharacterController.ShowStopClimbIcon();
                controller.m_CharacterController.RotateCanvas();
            }

        }
    }
}
