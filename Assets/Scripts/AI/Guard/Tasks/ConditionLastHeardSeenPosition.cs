using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionLastHeardSeenPosition : Task
    {
        public override TaskState Run()
        {
            //Debug.Log(m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination == m_BehaviourTree.m_Blackboard.GetVector3Value("LastPercievedPosition"));
            //Debug.Log(m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination);
            //Debug.Log(m_BehaviourTree.m_Blackboard.GetVector3Value("LastPercievedPosition"));

            if ((m_BehaviourTree.m_Blackboard.GetIntValue("GuardState") == (int)GuardState.ALARMED 
                || m_BehaviourTree.m_Blackboard.GetIntValue("GuardState") == (int)GuardState.CURIOUS) )
                // && m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination == m_BehaviourTree.m_Blackboard.GetVector3Value("LastPercievedPosition"))
            {
                //Debug.Log("Precondition has raeched");
                if(m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.remainingDistance <= m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.stoppingDistance)
                {
                    //Debug.Log("has reached last heard seen");
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