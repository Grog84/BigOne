using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StartItemCollect")]
    public class StartItemCollectAction : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            StartDoorInteraction(controller);
        }

        private void StartDoorInteraction(CharacterStateController controller)
        {

            controller.m_CharacterController.startItemAnimation = true;

        }
    }
}

