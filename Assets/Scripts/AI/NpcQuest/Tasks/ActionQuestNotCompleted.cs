using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionQuestNotCompleted : Task
    {
        public override TaskState Run()
        {
            //trigger animazione di NO
            m_BehaviourTree.m_Blackboard.m_Agent.m_Animator.SetTrigger("isNegative");

            return TaskState.SUCCESS;
        }
    }
}