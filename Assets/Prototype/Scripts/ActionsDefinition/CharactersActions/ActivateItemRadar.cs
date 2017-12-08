using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/ActivateItemRadar")]
    public class ActivateItemRadar : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            EnableItemRadar(controller);
        }

        private void EnableItemRadar(CharacterStateController controller)
        {
            controller.m_CharacterController.LookAtItems.SetActive(true);
        }
    }
}
