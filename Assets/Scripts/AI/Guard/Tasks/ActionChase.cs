using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionChase : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.destination = 
                GMController.instance.playerTransform[(int)GMController.instance.isCharacterPlaying].position;
            m_BehaviourTree.m_Blackboard.m_Agent.m_NavMeshAgent.isStopped = false;

            return TaskState.SUCCESS;;
        }
    }
}