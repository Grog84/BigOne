using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Audio/StopPush")]
    public class AudioStopPush : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            StopPush(controller);
        }

        public void StopPush(CharacterStateController controller)
        {
            controller.m_CharacterController.playLoop.StopSound("Pull");
            controller.m_CharacterController.playLoop.StopSound("Push");
        }

    }
}
