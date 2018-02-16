using UnityEngine;

namespace AI.BT
{
    public class ConditionPlayerReached : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("PlayerInSight"))
            {
                float playerDistance = (m_BehaviourTree.m_Blackboard.m_Agent.transform.position - 
                    GMController.instance.m_CharacterInterfaces[(int)GMController.instance.isCharacterPlaying].transform.position).magnitude;
                //Debug.Log("PlayerReached");
                //if ((m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.remainingDistance <= m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.stoppingDistance) &&
                //    !m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.isPathStale)
                if ((playerDistance <= m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.stoppingDistance) &&
                    !m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.isPathStale)
                    {
                    return TaskState.SUCCESS;
                }
                else
                    return TaskState.FAILURE;
            }
            else
                return TaskState.FAILURE;
        }
    }
}