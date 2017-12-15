using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/GM/DeathAnimationFinished")]
    public class DeathAnimationFinished : Decision
    {
        public override bool Decide(GMStateController controller)
        {
            return controller.m_GM.deathTimer >= controller.m_GM.deathAnimationTime;
        }
    }
}
