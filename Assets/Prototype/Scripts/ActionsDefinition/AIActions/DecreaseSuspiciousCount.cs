using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/DecreaseSuspiciousCount")]
public class DecreaseSuspiciousCount : _Action {

    public override void Execute(EnemiesAIStateController controller)
    {
        DecreaseCount(controller);
    }

    private void DecreaseCount(EnemiesAIStateController controller)
    {
        controller.m_AgentController.isSuspicious = false;
        GMController.instance.suspiciousGuards -= 1;
    }
}
