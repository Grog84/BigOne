using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionCurious : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetIntValue("GuardState") == (int)GuardState.CURIOUS)
                return TaskState.SUCCESS;
            else
                return TaskState.FAILURE;
        }
    }
}