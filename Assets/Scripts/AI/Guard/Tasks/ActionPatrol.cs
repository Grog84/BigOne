using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionPatrol : Task
    {
        public override TaskState Run()
        {
            Guard guard = m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>();

            m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination = guard.wayPointListTransform[guard.nextWayPoint].position;
            m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.isStopped = false;

            //guard.checkNavPointTime = guard.wayPointList[guard.nextWayPoint].secondsStaying;
            //if (guard.checkNavPointTime != 0f)
            //{
            //    m_BehaviourTree.m_Blackboard.SetBoolValue("CheckingNavPoint", true);
            //    guard.checkingWayPoint = guard.nextWayPoint;
            //}

            if (guard.randomPick)
            {
                int nextPoint = guard.nextWayPoint;
                while (nextPoint == guard.nextWayPoint)
                {
                    nextPoint = Random.Range(0, guard.wayPointList.Count);
                }
                guard.nextWayPoint = nextPoint;
            }
            else
                guard.nextWayPoint = (guard.nextWayPoint + 1) % guard.wayPointList.Count;
            
            
            return TaskState.SUCCESS;
        }
    }
}