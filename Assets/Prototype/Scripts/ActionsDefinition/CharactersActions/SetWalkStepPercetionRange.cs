﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using AI;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/SetWalkStepPercetionRange")]
    public class SetWalkStepPercetionRange : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            SetRange(controller);
        }

        private void SetRange(CharacterStateController controller)
        {
            controller.m_CharacterController.walkStatusRange = controller.m_CharacterController.m_CharStats.m_WalkSoundrange;
        }

    }
}
