using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/CrouchRaycastPosition")]
    public class CrouchRaycastPosition : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            CrouchRayPos(controller);
        }

        private void CrouchRayPos(CharacterStateController controller)
        {
            if (controller.m_CharacterController.firstCrouch == false)
            {
                float sizeX = controller.m_CharacterController.m_CharController.bounds.size.x / 2;
                float sizeZ = controller.m_CharacterController.m_CharController.bounds.size.z / 2;
                float sizeY = controller.m_CharacterController.m_CharController.bounds.size.y / 2;

                controller.m_CharacterController.BoundRaycasts[0] = new Vector3(0, sizeY * 2, 0);
                controller.m_CharacterController.BoundRaycasts[1] = new Vector3(sizeX, sizeY * 2, 0);
                controller.m_CharacterController.BoundRaycasts[2] = new Vector3(0, sizeY * 2, sizeZ);
                controller.m_CharacterController.BoundRaycasts[3] = new Vector3(-sizeX, sizeY * 2, 0);
                controller.m_CharacterController.BoundRaycasts[4] = new Vector3(0, sizeY * 2, -sizeZ);

                controller.m_CharacterController.firstCrouch = true;
            }
        }
    }
}
