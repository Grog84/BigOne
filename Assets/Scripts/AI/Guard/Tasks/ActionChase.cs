using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionChase : Task
    {
        public override TaskState Run()
        {
            //m_BehaviourTree.m_Blackboard.m_NavMeshAgent.destination = controller.m_AgentController.chaseTarget.position;
            //controller.m_AgentController.m_NavMeshAgent.isStopped = false;

            return TaskState.SUCCESS;;
        }
    }
}