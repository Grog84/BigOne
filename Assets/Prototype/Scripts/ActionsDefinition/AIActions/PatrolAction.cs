using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/Patrol")]
public class PatrolAction : _Action
{
    public override void Execute(EnemiesAIStateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(EnemiesAIStateController controller)
    {
        controller.m_AgentController.m_NavMeshAgent.destination = controller.m_AgentController.wayPointList[controller.m_AgentController.nextWayPoint].position;
        controller.m_AgentController.m_NavMeshAgent.isStopped = false;

        if (controller.m_AgentController.m_NavMeshAgent.remainingDistance <= controller.m_AgentController.m_NavMeshAgent.stoppingDistance && !controller.m_AgentController.m_NavMeshAgent.pathPending)
        {
            controller.m_AgentController.nextWayPoint = (controller.m_AgentController.nextWayPoint + 1) % controller.m_AgentController.wayPointList.Count;
        }
    }
}