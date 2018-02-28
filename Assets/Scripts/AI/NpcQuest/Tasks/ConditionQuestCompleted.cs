using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionQuestCompleted : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("nextQuestCompleted") && !m_BehaviourTree.m_Blackboard.GetBoolValue("questFinisherCompleted") && m_BehaviourTree.m_Blackboard.GetBoolValue("nextQuestActive"))
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}