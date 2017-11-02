using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/LoadPatrolStats")]
    public class LoadPatrolStats : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            LoadPatrolParams(controller);
        }

        private void LoadPatrolParams(EnemiesAIStateController controller)
        {
            controller.m_AgentController.UpdateStats("patrol");
        }
    }
}
