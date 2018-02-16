using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionIsWaiting : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("CheckingNavPoint"))
            {
                //Debug.Log("Condition is waiting");
                return TaskState.SUCCESS;
            }
            else
            {
                return TaskState.FAILURE;
            }
        }
    }
}