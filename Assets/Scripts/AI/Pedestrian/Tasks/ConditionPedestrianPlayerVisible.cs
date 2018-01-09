using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionPedestrianPlayerVisible : Task 
    {

        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("PlayerInSight"))
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}