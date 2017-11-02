using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Audio/SetRun")]
    public class AudioSetRun : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            AudioWalk(controller);
        }

        public void AudioWalk(CharacterStateController controller)
        {
            controller.m_CharacterController.footStepsEmitter.SetState("Run");
        }

    }
}
