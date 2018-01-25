using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using DG.Tweening;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Push")]
    public class PushAction : _Action
    {
        Vector3[] RaycastPoints;
        float forward;
        float backward;
        float movement;
        float offsetRaycast;
        int dir;
        int count;
        


        public override void Execute(CharacterStateController controller)
        {
            Push(controller);
        }

        private void Push(CharacterStateController controller)
        {
            #region Reycasts
            // Check the direction for the Raycast
            if (Vector3.Angle(controller.m_CharacterController.pushObject.transform.forward.normalized, controller.m_CharacterController.CharacterTransform.forward.normalized) <= 45 ||
                Vector3.Angle(controller.m_CharacterController.pushObject.transform.forward.normalized, -controller.m_CharacterController.CharacterTransform.forward.normalized) <= 45)
            {
                RaycastPoints = controller.m_CharacterController.pushCollider.transform.parent.GetComponent<PushRaycast>().objectRaycastsX;
                offsetRaycast = controller.m_CharacterController.pushCollider.transform.parent.GetComponent<PushRaycast>().quarterWidth * 2;
            }
            else
            {
                RaycastPoints = controller.m_CharacterController.pushCollider.transform.parent.GetComponent<PushRaycast>().objectRaycastsZ;
                offsetRaycast = controller.m_CharacterController.pushCollider.transform.parent.GetComponent<PushRaycast>().quarterDepth * 2;
            }
            // Use the Raycast grid to check for obstacles
            count = RaycastPoints.Length;
            for (int i = 0; i < RaycastPoints.Length; i++)
            {
                Debug.DrawRay(controller.m_CharacterController.pushObject.transform.position + RaycastPoints[i], controller.m_CharacterController.pushCollider.transform.forward * dir, Color.red);
                RaycastHit hit;

                if (Physics.Raycast(controller.m_CharacterController.pushObject.transform.position +
                    RaycastPoints[i], controller.m_CharacterController.pushCollider.transform.forward * dir,
                    out hit, controller.m_CharacterController.m_CharStats.m_DistanceFromPushableObstacle + offsetRaycast))
                {

                    // Layers of Obastacles
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Climbable") ||
                              hit.transform.gameObject.layer == LayerMask.NameToLayer("Doors")|| hit.transform.gameObject.layer == LayerMask.NameToLayer("Pushable") ||
                              hit.transform.gameObject.layer == LayerMask.NameToLayer("Stairs"))
                    {
                        controller.m_CharacterController.isPushLimit = true;
                        count--;
                    }
                }
                if (count == RaycastPoints.Length)
                {
                    controller.m_CharacterController.isPushLimit = false;
                }

            }
#endregion

            #region Animator
            if (Input.GetAxis("Vertical")!= 0 || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
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
            #endregion

            #region Movements
    
            if (Input.GetAxis("Vertical") > 0)
            {
                forward = Input.GetAxis("Vertical");
                dir = 1;
            }
            else
            {
                forward = 0;
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                backward = Input.GetAxis("Vertical");;
                dir = -1;
            }
            else 
            {
                backward = 0;
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
            {
                backward = 0;
                forward = 0;
            }

            Debug.Log(dir);
            if (controller.m_CharacterController.isPushLimit)
            {
                if (dir < 0)
                {
                    controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.pushCollider.transform.forward * forward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1   
                }
                else if (dir > 0)
                {
                    controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.pushCollider.transform.forward * backward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1 
                }
            }
            else if (!controller.m_CharacterController.isPushLimit)
            {
                controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.pushCollider.transform.forward * forward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
                controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.pushCollider.transform.forward * backward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
            }
#endregion
            // For Animator
            controller.m_CharacterController.m_ForwardAmount = movement;
            //

            controller.m_CharacterController.RotateCanvas();
        }
    }
}
