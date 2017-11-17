using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/DeactivateCancelIcon")]
    public class DeactivateCancelIcon : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            ActivateIcon(controller);
        }

        private void ActivateIcon(CharacterStateController controller)
        {
            controller.m_CharacterController.HideCancelIcon();
        }
    }
}
