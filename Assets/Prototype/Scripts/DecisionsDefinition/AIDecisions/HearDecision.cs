using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearDecision : Decision {

    public override bool Decide(EnemiesAIStateController controller)
    {
        return controller.m_AgentController.hasHeardPlayer;
    }

}
