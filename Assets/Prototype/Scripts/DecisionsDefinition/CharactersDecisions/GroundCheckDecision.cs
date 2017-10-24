using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachine
{


    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/GroundCheck")]
    public class GroundCheckDecision : Decision
    {
        public float verticalOffset = 0.5f;
        public float verticalMainOffset = 0.1f;
        public float horizontalOffset = 0.5f;
        public int raycastCollided;
        bool isOnTheGround;
        public bool[] hits = new bool[5];
        float secondaryRaycastDistance;

        public override bool Decide(CharacterStateController controller)
        {
            raycastCollided = CheckIsOnGround(controller);
            if (raycastCollided > 0)
            {
                isOnTheGround = true;
            }
            else
            {
                isOnTheGround = false;
            }


            return isOnTheGround;
        }

        private int CheckIsOnGround(CharacterStateController controller)
        {
            secondaryRaycastDistance = controller.characterStats.m_GroundCheckDistance + 1 - verticalMainOffset;
            RaycastHit hitInfo;


#if UNITY_EDITOR
            // helper to visualise the ground check ray in the scene view
            Debug.DrawLine(controller.m_CharacterController.CharacterTansform.position + Vector3.up * verticalOffset,
                            controller.m_CharacterController.CharacterTansform.position + (Vector3.down * controller.characterStats.m_GroundCheckDistance), Color.green);

#endif
            // creating an array of bool given by the raycasts to make the check more precise
            // it is also good to note that the transform position in the sample assets is at the base of the character
            // Debug.Log(Physics.Raycast(controller.m_CharacterController.CharacterTansform.position + Vector3.up * offset, Vector3.down, out hitInfo, 0.15f));
            if (Physics.Raycast(controller.m_CharacterController.CharacterTansform.position + Vector3.up * verticalMainOffset, Vector3.down, out hitInfo, controller.characterStats.m_GroundCheckDistance))
            {
                hits[0] = true;

            }
            else
            {
                hits[0] = false;
            }

            if (Physics.Raycast(controller.m_CharacterController.CharacterTansform.position + Vector3.up + Vector3.left * horizontalOffset, Vector3.down, out hitInfo, secondaryRaycastDistance))
            {
                hits[1] = true;
            }
            else
            {
                hits[1] = false;
            }

            if (Physics.Raycast(controller.m_CharacterController.CharacterTansform.position + Vector3.up + Vector3.forward * horizontalOffset, Vector3.down, out hitInfo, secondaryRaycastDistance))
            {
                hits[2] = true;
            }
            else
            {
                hits[2] = false;
            }

            if (Physics.Raycast(controller.m_CharacterController.CharacterTansform.position + Vector3.up + Vector3.right * horizontalOffset, Vector3.down, out hitInfo, secondaryRaycastDistance))
            {
                hits[3] = true;
            }
            else
            {
                hits[3] = false;
            }

            if (Physics.Raycast(controller.m_CharacterController.CharacterTansform.position + Vector3.up + Vector3.back * horizontalOffset, Vector3.down, out hitInfo, secondaryRaycastDistance))
            {
                hits[4] = true;
            }
            else
            {
                hits[4] = false;
            }

            int count = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i] == true)
                {
                    count++;
                }
            }
            return count;
        }


    }
}