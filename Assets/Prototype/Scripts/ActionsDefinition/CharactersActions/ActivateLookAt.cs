using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/ActivateLookAt")]
    public class ActivateLookAt : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            EnableLookAt(controller);
        }

        private void EnableLookAt(CharacterStateController controller)
        {
            controller.m_CharacterController.canLookAt = true;      
        }
    }
}
