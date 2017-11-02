using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/LoadCheckNavPointStats")]
    public class LoadCheckNavPointStats : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            LoadCheckNavPoint(controller);
        }

        private void LoadCheckNavPoint(EnemiesAIStateController controller)
        {
            controller.m_AgentController.UpdateStats("checkNavPoint");
        }
    }
}
