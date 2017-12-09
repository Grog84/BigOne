﻿using System.Collections;
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
            m_BehaviourTree.m_Blackboard.m_Agent.m_Animator.SetTrigger("isGivingQuest");
            return TaskState.SUCCESS;
        }
    }
}