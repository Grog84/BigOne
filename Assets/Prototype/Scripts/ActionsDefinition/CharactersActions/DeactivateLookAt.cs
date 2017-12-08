using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/DeactivateLookAt")]
    public class DeactivateLookAt : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            DisableLookAt(controller);
        }

        private void DisableLookAt(CharacterStateController controller)
        {
            controller.m_CharacterController.dontLookAt = true;      
        }
    }
}
