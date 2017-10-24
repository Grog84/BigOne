using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/CheckLastSeen")]
    public class CheckLastSeen : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            CheckLastSeenPosition(controller);
        }

        private void CheckLastSeenPosition(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_NavMeshAgent.destination = GMController.instance.lastSeenPlayerPosition;
            controller.m_AgentController.m_NavMeshAgent.isStopped = false;
        }

    }
}
