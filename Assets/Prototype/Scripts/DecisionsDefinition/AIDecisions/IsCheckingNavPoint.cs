using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/AI/IsCheckingNavPoint")]
    public class IsCheckingNavPoint : Decision
    {

        public override bool Decide(EnemiesAIStateController controller)
        {
            return controller.m_AgentController.isCheckingNavPoint;
        }

    }
}
