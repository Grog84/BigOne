using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/LandMovement")]
    public class MovementAction : _Action
    {
        Vector3 m_Move;
        Vector3 m_CamForward;


        public override void Execute(CharacterStateController controller)
        {
            Walk(controller);
        }

        private void Walk(CharacterStateController controller)
        {

            //float get from the axis used in the vector3 m_Move
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            //calculate move direction to pass to character
            if (controller.m_CharacterController.m_Camera != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(controller.m_CharacterController.m_Camera.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = (v * m_CamForward + h * controller.m_CharacterController.m_Camera.right);
            }


            if (m_Move.sqrMagnitude > 1)
            {
                m_Move = m_Move.normalized;
            }

            // Debug.Log(m_Move);
            m_Move *= controller.characterStats.m_MovementSpeed;



            //make the model face the camera direction
            if (m_Move != Vector3.zero)
                controller.m_CharacterController.CharacterTransform.forward = m_Move;

            //apply gravity if needed when walking
            m_Move.y -= controller.characterStats.m_Gravity;
            controller.m_CharacterController.m_CharController.Move(m_Move * Time.deltaTime);

            // For Animator
            if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
            {

                if(v>h)
                {
                    controller.m_CharacterController.m_ForwardAmount = Mathf.Abs(v);
                    return;
                }
                else if(h>v)
                {
                    controller.m_CharacterController.m_ForwardAmount = Mathf.Abs(h);
                    return;
                }
                
            }
            else if(Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0)
            {
                if(v<h)
                {
                    controller.m_CharacterController.m_ForwardAmount = Mathf.Abs(v);
                    return;
                }
                else if (h<v)
                {
                    controller.m_CharacterController.m_ForwardAmount = Mathf.Abs(h);
                    return;
                }
            }
            /*if (Input.GetAxis("Horizontal") != 0)
            {
                controller.m_CharacterController.m_ForwardAmount = Mathf.Abs(h);
                return;
            }*/
        }
    }
}
