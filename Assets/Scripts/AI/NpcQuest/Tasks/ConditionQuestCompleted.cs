using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionQuestCompleted : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("questAvailable") && !m_BehaviourTree.m_Blackboard.GetBoolValue("questCompleted") && m_BehaviourTree.m_Blackboard.GetBoolValue("objectiveComplete"))
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}