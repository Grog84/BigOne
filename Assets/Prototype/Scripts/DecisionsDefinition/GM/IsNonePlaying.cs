using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/GM/IsNonePlaying")]
    public class IsNonePlaying : Decision
    {
        public override bool Decide(GMStateController controller)
        {
            return controller.m_GM.isCharacterPlaying == CharacterActive.None;
        }
    }
}
