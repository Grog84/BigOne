using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/IncreaseSuspiciousCount")]
    public class IncreaseSuspiciousCount : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            IncreaseCount(controller);
        }

        private void IncreaseCount(EnemiesAIStateController controller)
        {
            if (!controller.m_AgentController.isSuspicious && !controller.m_AgentController.isAlarmed)
            {
                controller.m_AgentController.isSuspicious = true;
                GMController.instance.suspiciousGuards += 1;
            }
        }
    }
}
