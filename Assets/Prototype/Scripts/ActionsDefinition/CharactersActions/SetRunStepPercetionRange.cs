using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using AI;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/SetRunStepPercetionRange")]
    public class SetRunStepPercetionRange : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            SetRange(controller);
        }

        private void SetRange(CharacterStateController controller)
        {
            controller.m_CharacterController.UpdateSoundStatus(SoundStatus.RUN);
        }

    }
}
