using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionSwitchNavPoint : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("RandomPick"))
            {
                int nextPoint = m_BehaviourTree.m_Blackboard.GetIntValue("CurrentNavPoint");
                while (nextPoint == m_BehaviourTree.m_Blackboard.GetIntValue("CurrentNavPoint"))
                {
                    nextPoint = Random.Range(0, m_BehaviourTree.m_Blackboard.GetIntValue("NumberOfNavPoints"));
                }
                m_BehaviourTree.m_Blackboard.SetIntValue("CurrentNavPoint", nextPoint);
                m_BehaviourTree.m_Blackboard.m_Agent.UpdateNavPoint();
            }
            else
            {
                m_BehaviourTree.m_Blackboard.SetIntValue("CurrentNavPoint",(m_BehaviourTree.m_Blackboard.GetIntValue("CurrentNavPoint") + 1) % m_BehaviourTree.m_Blackboard.GetIntValue("NumberOfNavPoints"));
                m_BehaviourTree.m_Blackboard.m_Agent.UpdateNavPoint();
            }
            return TaskState.SUCCESS;
        }
    }
}