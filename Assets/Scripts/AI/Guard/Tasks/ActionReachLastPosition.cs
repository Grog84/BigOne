using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionReachLastPosition : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination = 
                m_BehaviourTree.m_Blackboard.GetVector3Value("LastPercievedPosition");

            return TaskState.SUCCESS;;
        }
    }
}