using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionHoldPosition : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.isStopped = true;
            m_BehaviourTree.m_Blackboard.SetBoolValue("IsRelaxing", true);
            return TaskState.SUCCESS;
        }
    }
}