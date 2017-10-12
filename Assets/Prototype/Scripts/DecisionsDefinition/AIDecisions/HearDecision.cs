using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/CheckLastHeard")]
public class HearDecision : _Action {

    public override void Execute(EnemiesAIStateController controller)
    {
        CheckLastHeard(controller);
    }

    private void CheckLastHeard(EnemiesAIStateController controller)
    {
        controller.m_AgentController.m_NavMeshAgent.destination = GMController.instance.lastSeenPlayerPosition;
        controller.m_AgentController.m_NavMeshAgent.isStopped = false;
    }

}
