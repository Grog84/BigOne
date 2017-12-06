using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionWatchPlayer : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.SetBoolValue("lookAtPlayer", true);
            return TaskState.SUCCESS;
        }
    }
}