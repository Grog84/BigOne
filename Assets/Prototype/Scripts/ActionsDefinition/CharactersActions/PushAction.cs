using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
<<<<<<< HEAD
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Push")]
    public class PushAction : _Action
=======
    //Vector3 m_Move;
    float forward;
    float backward;
    float movement;

    public override void Execute(CharacterStateController controller)
>>>>>>> f33a8f5
    {
        Vector3[] RaycastPoints;
        float forward;
        float backward;
        float movement;

<<<<<<< HEAD

        public override void Execute(CharacterStateController controller)
        {
            Push(controller);
        }

        private void Push(CharacterStateController controller)
        {


            if (Vector3.Angle(controller.m_CharacterController.pushObject.transform.forward.normalized, controller.m_CharacterController.CharacterTansform.forward.normalized) <= 45 ||
                Vector3.Angle(controller.m_CharacterController.pushObject.transform.forward.normalized, -controller.m_CharacterController.CharacterTansform.forward.normalized) <= 45)
            {
                RaycastPoints = controller.m_CharacterController.pushCollider.transform.parent.GetComponent<PushRaycast>().objectRaycastsX;
            }
            else
            {
                RaycastPoints = controller.m_CharacterController.pushCollider.transform.parent.GetComponent<PushRaycast>().objectRaycastsZ;
            }

            for (int i = 0; i < RaycastPoints.Length; i++)
            {
                Debug.DrawRay(controller.m_CharacterController.pushObject.transform.position + RaycastPoints[i], controller.m_CharacterController.CharacterTansform.forward, Color.red);
                RaycastHit hit;

                if (Physics.Raycast(controller.m_CharacterController.pushObject.transform.position +
                    RaycastPoints[i], controller.m_CharacterController.CharacterTansform.forward,
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

=======
    private void Push(CharacterStateController controller)
    {
        Debug.DrawRay(controller.m_CharacterController.pushObject.transform.position + new Vector3(0,controller.characterStats.m_PushableObjectRaycastOffset,0), controller.m_CharacterController.CharacterTansform.forward, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(controller.m_CharacterController.pushObject.transform.position +
            new Vector3(0, controller.characterStats.m_PushableObjectRaycastOffset, 0), controller.m_CharacterController.CharacterTansform.forward, 
            out hit, controller.m_CharacterController.m_CharStats.m_DistanceFromPushableObstacle))
        {
            

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Climbable") ||
                      hit.transform.gameObject.layer == LayerMask.NameToLayer("Doors"))
            {
                Debug.Log("vedo ostacolo");
                controller.m_CharacterController.isPushLimit = true;
                Debug.Log(controller.m_CharacterController.isPushLimit);
            }
            else
            {
                controller.m_CharacterController.isPushLimit = false;
                Debug.Log(controller.m_CharacterController.isPushLimit);
>>>>>>> f33a8f5
            }

        }
        else
        {
            controller.m_CharacterController.isPushLimit = false;
        }
       
        
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                movement = Input.GetAxis("Vertical");
            }
            else
            {
                movement = 0;
            }

            if (Input.GetKey(KeyCode.W))
            {
                forward = Input.GetAxis("Vertical");
            }
            else
            {
                forward = 0;
            }

            if (Input.GetKey(KeyCode.S))
            {
                backward = Input.GetAxis("Vertical");
            }
            else
            {
                backward = 0;
            }

            if (controller.m_CharacterController.isPushLimit)
            {
                controller.m_CharacterController.CharacterTansform.Translate(Vector3.forward * backward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1          
            }
            else if (!controller.m_CharacterController.isPushLimit)
            {
                controller.m_CharacterController.CharacterTansform.Translate(Vector3.forward * forward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
                controller.m_CharacterController.CharacterTansform.Translate(Vector3.forward * backward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
            }

            controller.m_CharacterController.m_ForwardAmount = movement;

        }
    }
}
