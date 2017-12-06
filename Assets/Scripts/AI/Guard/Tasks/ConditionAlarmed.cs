using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionAlarmed : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetIntValue("GuardState") == (int)GuardState.ALARMED)
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}