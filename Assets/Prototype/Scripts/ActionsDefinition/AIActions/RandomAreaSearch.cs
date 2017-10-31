using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.AI;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/RandomAreaSearch")]
    public class RandomAreaSearch : _Action
    {
        public override void Execute(EnemiesAIStateController controller)
        {
            AreaSearch(controller);
        }

        private void GetRandomPoint(EnemiesAIStateController controller, out Vector3 result)
        {
            for (int i = 0; i < 30; i++)
            {
                Vector3 randomPoint = controller.transform.position + Random.insideUnitSphere * controller.m_AgentController.agentStats.localSearchRange;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                }
            }
            result = controller.transform.position;     
        }

        private void AreaSearch(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_NavMeshAgent.destination = controller.m_AgentController.randomDestination;
            controller.m_AgentController.m_NavMeshAgent.isStopped = false;

            if (controller.m_AgentController.m_NavMeshAgent.remainingDistance <= controller.m_AgentController.m_NavMeshAgent.stoppingDistance && !controller.m_AgentController.m_NavMeshAgent.pathPending)
            {
                GetRandomPoint(controller, out controller.m_AgentController.randomDestination);
            }

        }
    }
}