using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/AI/SearchLongEnough")]
    public class SearchLongEnough : Decision
    {

        public override bool Decide(EnemiesAIStateController controller)
        {
            return controller.stateTimeElapsed >= controller.m_AgentController.agentStats.localSearchTime;
        }

    }
}
