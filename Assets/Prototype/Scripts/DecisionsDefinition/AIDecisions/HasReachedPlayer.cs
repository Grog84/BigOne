using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/AI/HasReachedPlayer")]
    public class HasReachedPlayer : Decision
    {

        public override bool Decide(EnemiesAIStateController controller)
        {
            bool hasReachedPlay = HasReachedPlayPos(controller);
            return hasReachedPlay;
        }

        private bool HasReachedPlayPos(EnemiesAIStateController controller)
        {
            bool hasReached = false;

            // Check if we've reached the destination
            if (!controller.m_AgentController.m_NavMeshAgent.pathPending)
            {
                if (controller.m_AgentController.m_NavMeshAgent.remainingDistance <= controller.m_AgentController.m_NavMeshAgent.stoppingDistance)
                {
                    hasReached = true;
                }
            }

            return hasReached;
        }

    }
}
