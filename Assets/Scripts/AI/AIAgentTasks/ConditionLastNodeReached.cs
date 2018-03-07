using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionLastNodeReached : Task
    {
        public override TaskState Run()
        {
			//Debug.Log("destination reached?");
            if (m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.remainingDistance 
                <= m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.stoppingDistance)
            {
                Debug.Log("destination reached");
                return TaskState.SUCCESS;

            }
            else
                return TaskState.FAILURE;
        }
    }
}