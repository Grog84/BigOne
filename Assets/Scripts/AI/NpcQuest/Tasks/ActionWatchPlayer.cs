using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionWatchPlayer : Task
    {
        public override TaskState Run()
        {
            Debug.Log("Guardo!!!");
            m_BehaviourTree.m_Blackboard.SetBoolValue("lookAtPlayer", true);
            //m_BehaviourTree.m_Blackboard.m_Agent.m_Animator.SetTrigger("PlayerSaw");
            return TaskState.SUCCESS;
        }
    }
}