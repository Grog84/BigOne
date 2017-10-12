using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/AI/Hear")]
public class HasHeardPlayer : Decision {

    public override bool Decide(EnemiesAIStateController controller)
    {
        return controller.m_AgentController.hasHeardPlayer;
    }
}
