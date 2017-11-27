using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionLastHeardSeenPosition : Task
    {
        public override TaskState Run()
        {
            if( m_BehaviourTree.m_Blackboard.GetIntValue("GuardState") == (int)GuardState.ALARMED &&
                m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination == GMController.instance.lastPercievedPlayerPosition)
            {
                if(m_BehaviourTree.m_Blackboard.m_Agent.transform.position == m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination)
                    return TaskState.SUCCESS;
                else
                    return TaskState.FAILURE;
            }
            else
                return TaskState.FAILURE;
        }
    }
}