using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/GM/FadeOver")]
    public class FadeOver : Decision
    {

        public override bool Decide(GMStateController controller)
        {
            return controller.m_GM.fadeEffect.color.a == 0;
        }
    }
}
