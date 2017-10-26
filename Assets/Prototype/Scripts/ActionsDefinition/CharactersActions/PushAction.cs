using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Push")]
    public class PushAction : _Action
    {
        Vector3[] RaycastPoints;
        float forward;
        float backward;
        float movement;


        public override void Execute(CharacterStateController controller)
        {
            Push(controller);
        }

        private void Push(CharacterStateController controller)
        {

            // Check the direction for the Raycast
            if (Vector3.Angle(controller.m_CharacterController.pushObject.transform.forward.normalized, controller.m_CharacterController.CharacterTansform.forward.normalized) <= 45 ||
                Vector3.Angle(controller.m_CharacterController.pushObject.transform.forward.normalized, -controller.m_CharacterController.CharacterTansform.forward.normalized) <= 45)
            {
                RaycastPoints = controller.m_CharacterController.pushCollider.transform.parent.GetComponent<PushRaycast>().objectRaycastsX;
            }
            else
            {
                RaycastPoints = controller.m_CharacterController.pushCollider.transform.parent.GetComponent<PushRaycast>().objectRaycastsZ;
            }
            // Use the Raycast grid to check for obstacles
            for (int i = 0; i < RaycastPoints.Length; i++)
            {
                Debug.DrawRay(controller.m_CharacterController.pushObject.transform.position + RaycastPoints[i], controller.m_CharacterController.pushCollider.transform.forward, Color.red);
                RaycastHit hit;

                if (Physics.Raycast(controller.m_CharacterController.pushObject.transform.position +
                    RaycastPoints[i], controller.m_CharacterController.pushCollider.transform.forward,
                    out hit, controller.m_CharacterController.m_CharStats.m_DistanceFromPushableObstacle))
                {


                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Climbable") ||
                              hit.transform.gameObject.layer == LayerMask.NameToLayer("Doors"))
                    {
                        Debug.Log("vedo ostacolo");
                        controller.m_CharacterController.isPushLimit = true;
                        Debug.Log(controller.m_CharacterController.isPushLimit);
                    }

                }

            }
            // For Animator
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                movement = Input.GetAxis("Vertical");
            }
            else
            {
                movement = 0;
            }
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                movement = 0;
            }

            // For actual Movements
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                forward = Input.GetAxis("Vertical");
            }
            else
            {
                forward = 0;
            }

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                backward = Input.GetAxis("Vertical");
                controller.m_CharacterController.isPushLimit = false;
            }
            else 
            {
                backward = 0;
            }


            if (controller.m_CharacterController.isPushLimit)
            {
                controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.pushCollider.transform.forward * backward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1          
            }
            else if (!controller.m_CharacterController.isPushLimit)
            {
                controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.pushCollider.transform.forward * forward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
                controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.pushCollider.transform.forward * backward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
            }
            // For Animator
            controller.m_CharacterController.m_ForwardAmount = movement;

        }
    }
}
