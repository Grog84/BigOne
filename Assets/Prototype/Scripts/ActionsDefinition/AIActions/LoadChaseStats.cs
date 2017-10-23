﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/LoadChaseStats")]
    public class LoadChaseStats : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            LoadCheckPositionParams(controller);
        }

        private void LoadCheckPositionParams(EnemiesAIStateController controller)
        {
            controller.m_AgentController.UpdateStats("chase");
        }
    }
}
