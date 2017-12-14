using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionQuestAvailable : Task
    {
        public override TaskState Run()
        {

            if (m_BehaviourTree.m_Blackboard.GetBoolValue("questAvailable") && !m_BehaviourTree.m_Blackboard.GetBoolValue("questActive"))
            {
                m_BehaviourTree.m_Blackboard.SetBoolValue("questActive", true);
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}