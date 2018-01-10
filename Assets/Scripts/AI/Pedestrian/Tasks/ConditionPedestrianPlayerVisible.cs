﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionPedestrianPlayerVisible : Task 
    {
        Pedestrian pedestrian;
        public override TaskState Run()
        {
            pedestrian = (Pedestrian)m_BehaviourTree.m_Blackboard.m_Agent;
            pedestrian.LookAtPlayer();

            if (m_BehaviourTree.m_Blackboard.GetBoolValue("PlayerIsVisible"))
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}