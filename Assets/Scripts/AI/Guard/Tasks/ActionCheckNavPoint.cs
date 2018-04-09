using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionCheckNavPoint : Task
    {

        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetBoolValue("WaitingCoroutineRunning"))
            {
                return TaskState.SUCCESS;
            }
            else
            {
                m_BehaviourTree.m_Blackboard.SetBoolValue("WaitingCoroutineRunning", true);
                m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().CheckNextPoint();
                return TaskState.SUCCESS;
            }
        }
    }
}