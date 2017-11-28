using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionRandomPatrol : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.SetBoolValue("RandomPick", true); 

            return TaskState.SUCCESS;;
        }
    }
}