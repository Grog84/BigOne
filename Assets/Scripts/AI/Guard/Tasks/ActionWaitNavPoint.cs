using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionWaitNavPoint : Task
    {
        public override TaskState Run()
        {
            Guard guard = m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>();

            guard.checkNavPointTime = guard.wayPointList[guard.nextWayPoint].secondsStaying;
            if (guard.checkNavPointTime != 0f)
            {
                m_BehaviourTree.m_Blackboard.SetBoolValue("CheckingNavPoint", true);
                guard.checkingWayPoint = guard.nextWayPoint;
            }
            return TaskState.SUCCESS;
        }
    }
}