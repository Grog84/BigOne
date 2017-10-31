using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using AI;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/SetRunStepPercetionRange")]
    public class SetRunStepPercetionRange : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            SetRange(controller);
        }

        private void SetRange(CharacterStateController controller)
        {
            controller.m_CharacterController.walkStatusRange = controller.m_CharacterController.m_CharStats.m_RunSoundrange;
        }

    }
}
