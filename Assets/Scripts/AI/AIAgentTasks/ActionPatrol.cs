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
            m_BehaviourTree.m_Blackboard.m_Agent.ReachNavPoint();

            return TaskState.SUCCESS;
        }
    }
}