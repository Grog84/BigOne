using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/AI/HasLostSight")]
public class HasLostSight : Decision {

    public override bool Decide(EnemiesAIStateController controller)
    {
        bool targetVisible = controller.m_AgentController.isPlayerInSight;
        return !targetVisible;
    }

}
