using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/GM/FadeVisible")]
    public class FadeScreenVisible : Decision
    {

        public override bool Decide(GMStateController controller)
        {
            return controller.m_GM.fadeEffect.color.a == 1;
        }
    }
}
