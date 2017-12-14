using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionPlayerInteracted : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("playerInteracted") == true)
            {

                m_BehaviourTree.m_Blackboard.SetBoolValue("playerInteracted", false);
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}