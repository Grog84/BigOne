using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionPatrol : Task
    {
        public override TaskState Run()
        {
            Debug.Log("Patrol");
            Guard guard = m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>();

            m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination = guard.wayPointListTransform[guard.nextWayPoint].position;
            m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.isStopped = false;

            return TaskState.SUCCESS;
        }
    }
}