using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/ExitCrouchOnDefeat")]
    public class ExitCrouchOnDefeat : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            DetachChild(controller);
        }

        private void DetachChild(CharacterStateController controller)
        {
            controller.m_CharacterController.Crouch = false;
        }
    }
}
