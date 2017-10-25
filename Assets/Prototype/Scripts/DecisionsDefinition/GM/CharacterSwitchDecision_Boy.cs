using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/GM/SwitchCharacterBoy")]
    public class CharacterSwitchDecision_Boy : Decision
    {
        public override bool Decide(GMStateController controller)
        {
            Debug.Log("Switch");
            return controller.m_GM.isCharacterPlaying == CharacterActive.Mother;
        }
    }
}