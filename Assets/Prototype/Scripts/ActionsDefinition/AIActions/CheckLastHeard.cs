using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/CheckLastHeard")]
    public class CheckLastHeard : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            CheckLastHeardPosition(controller);
        }

        private void CheckLastHeardPosition(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_NavMeshAgent.destination = GMController.instance.lastHeardPlayerPosition;
            controller.m_AgentController.m_NavMeshAgent.isStopped = false;
        }
    }
}
