using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionGiveReward : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.SetBoolValue("questCompleted", true);
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<QuestNpc>().m_PlayableDirector.Play();
            return TaskState.SUCCESS;
        }
    }
}