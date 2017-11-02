using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/ResetAlarmLevel")]
    public class ResetAlarmLevel : _Action
    {
        public override void Execute(EnemiesAIStateController controller)
        {
            ResetAlarm(controller);
        }

        private void ResetAlarm(EnemiesAIStateController controller)
        {
            controller.m_AgentController.sightPercentage = 0f;
            controller.m_AgentController.isAlarmed = false;
        }
    }
}