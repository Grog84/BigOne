using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionCheckNavPoint : Task
    {

        public override TaskState Run()
        {
            Debug.Log("CheckNavPointAction");
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().CheckNextPoint();
            return TaskState.SUCCESS;
        }
    }
}