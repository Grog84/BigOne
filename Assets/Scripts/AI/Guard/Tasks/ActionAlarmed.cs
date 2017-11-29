using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionAlarmed : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().GetAlarmed();
            

            return TaskState.SUCCESS;;
        }
    }
}