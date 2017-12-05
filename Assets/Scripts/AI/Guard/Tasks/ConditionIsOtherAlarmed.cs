using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionIsOtherAlarmed : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("OtherAlarmed"))
                return TaskState.SUCCESS;
            else
                return TaskState.FAILURE;
        }
    }
}