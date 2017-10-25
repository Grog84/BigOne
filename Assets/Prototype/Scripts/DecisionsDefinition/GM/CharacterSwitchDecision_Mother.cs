using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/GM/SwitchCharacterMother")]
    public class CharacterSwitchDecision_Mother : Decision
    {
        public override bool Decide(GMStateController controller)
        {
            return controller.m_GM.isCharacterPlaying == CharacterActive.Boy;
        }
    }
}