using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/LoadCheckPositionStats")]
    public class LoadCheckLastHeardStats : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            LoadCheckPositionParams(controller);
        }

        private void LoadCheckPositionParams(EnemiesAIStateController controller)
        {
            controller.m_AgentController.UpdateStats("checkForNoise");
        }
    }
}
