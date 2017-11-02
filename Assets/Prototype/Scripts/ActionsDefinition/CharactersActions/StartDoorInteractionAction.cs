using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StartDoorInteraction")]
    public class StartDoorInteractionAction : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            StartDoorInteraction(controller);
        }

        private void StartDoorInteraction(CharacterStateController controller)
        {
            controller.m_CharacterController.doorObject = controller.m_CharacterController.doorCollider.transform.parent.gameObject;
            controller.m_CharacterController.startDoorAnimation = true;

        }
    }
}

