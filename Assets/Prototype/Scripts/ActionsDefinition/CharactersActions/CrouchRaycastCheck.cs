using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/CrouchRaycastCheck")]
    public class CrouchRaycastCheck : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            CrouchRayCheck(controller);
        }

        private void CrouchRayCheck(CharacterStateController controller)
        {
            RaycastHit hit;

            for (int i = 0; i < controller.m_CharacterController.BoundRaycasts.Length; i++)
            {
                Debug.DrawRay(controller.m_CharacterController.BoundRaycasts[i] + Vector3.up, Vector3.up, Color.red);

                //if (Physics.Raycast(controller.m_CharacterController.BoundRaycasts[i] + Vector3.up, Vector3.up, out hit, controller.characterStats.m_CrouchRay ))
                //{
                //    if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Default"))
                //    {
                //        controller.m_CharacterController.canStand = false;
                //    }
                //    else
                //    {
                //        controller.m_CharacterController.canStand = true;
                //    }
                //}
            }

        }
    }
}
