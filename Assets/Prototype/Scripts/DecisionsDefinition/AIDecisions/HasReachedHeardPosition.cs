using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/AI/HasReachedHeardPosition")]
    public class HasReachedHeardPosition : Decision
    {

        public override bool Decide(EnemiesAIStateController controller)
        {
            bool hasReachedPos = HasReachedHeardPos(controller);
            return hasReachedPos;
        }

        private bool HasReachedHeardPos(EnemiesAIStateController controller)
        {
            bool hasReached = false;

            // Check if we've reached the destination
            if (!controller.m_AgentController.m_NavMeshAgent.pathPending)
            {
                if (controller.m_AgentController.m_NavMeshAgent.remainingDistance <= controller.m_AgentController.m_NavMeshAgent.stoppingDistance)
                {
                    //if (!controller.m_AgentController.m_NavMeshAgent.hasPath || controller.m_AgentController.m_NavMeshAgent.velocity.sqrMagnitude == 0f)
                    //{
                    hasReached = true;
                    //}
                }
            }

            return hasReached;
        }
    }
}
