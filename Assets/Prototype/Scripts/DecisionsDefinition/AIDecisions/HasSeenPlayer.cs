using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/AI/HasSeenPlayer")]
    public class HasSeenPlayer : Decision
    {

        public override bool Decide(EnemiesAIStateController controller)
        {
            if (controller.m_AgentController.sightPercentage >= 100f)
            {
                controller.m_AgentController.chaseTarget = GMController.instance.playerTransform[(int)GMController.instance.isCharacterPlaying];
                return true;
            }
            else
                return false;
        }


    }
}
