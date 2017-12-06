using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionStartWaiting : Task
    {
        public override TaskState Run()
        {
            //Guard m_Guard = m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>();
            //Debug.Log("StartWaiting");
            m_BehaviourTree.m_Blackboard.SetBoolValue("CheckingNavPoint", true);
            //Debug.Log("Check navpoint bool: " + m_BehaviourTree.m_Blackboard.GetBoolValue("ChekingNavPoint"));
            //m_BehaviourTree.m_Blackboard.SetFloatValue("NavPointTimer", m_Guard.wayPointList[m_BehaviourTree.m_Blackboard.GetIntValue("CurrentNavPoint")].secondsStaying);
            return TaskState.SUCCESS;  
        }
    }
}