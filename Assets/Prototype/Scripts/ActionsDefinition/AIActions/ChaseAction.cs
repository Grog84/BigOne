using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/Chase")]
    public class ChaseAction : _Action
    {
        public override void Execute(EnemiesAIStateController controller)
        {
            Chase(controller);
        }

        private void Chase(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_NavMeshAgent.destination = controller.m_AgentController.chaseTarget.position;
            controller.m_AgentController.m_NavMeshAgent.isStopped = false;
        }
    }
}
