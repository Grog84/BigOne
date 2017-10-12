﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/CheckLastHeard")]
public class CheckLastHeard : _Action {

    public override void Execute(EnemiesAIStateController controller)
    {
        CheckLastHeardPosition(controller);
    }

    private void CheckLastHeardPosition(EnemiesAIStateController controller)
    {
        controller.m_AgentController.m_NavMeshAgent.destination = GMController.instance.lastSeenPlayerPosition;
        controller.m_AgentController.m_NavMeshAgent.isStopped = false;
    }
}
