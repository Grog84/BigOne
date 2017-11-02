using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/LoadChaseStats")]
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
