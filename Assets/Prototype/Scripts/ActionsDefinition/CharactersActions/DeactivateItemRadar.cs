using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/DeactivateItemRadar")]
    public class DeactivateItemRadar : _Action
    {
        GameObject itemRadar;

        public override void Execute(CharacterStateController controller)
        {
            DisableItemRadar(controller);
        }

        private void DisableItemRadar(CharacterStateController controller)
        {
            GameObject itemRadar;
            itemRadar = controller.m_CharacterController.LookAtItems;
            controller.m_CharacterController.canLookAt = true;
            controller.m_CharacterController.playerSight.solver.target = controller.m_CharacterController.cameraPoint.transform;

            itemRadar.GetComponent<LookAtItems>().targets.Clear();
            itemRadar.SetActive(false);
        }
    }
}
