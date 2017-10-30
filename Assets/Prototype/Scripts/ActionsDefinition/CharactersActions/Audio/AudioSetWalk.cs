using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Audio/SetWalk")]
    public class AudioSetWalk : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            AudioWalk(controller);
        }

        public void AudioWalk(CharacterStateController controller)
        {
            controller.m_CharacterController.footStepsEmitter.SetState("Walk");
        }

    }
}
