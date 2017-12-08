using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionRequest : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.SetBoolValue("questAvailable", true);
            //triggera booleano di animator
            return TaskState.SUCCESS;
        }
    }
}