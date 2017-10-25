using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/GM/IsMotherPlaying")]
    public class IsMotherPlaying : Decision
    {
        public override bool Decide(GMStateController controller)
        {
            return controller.m_GM.isCharacterPlaying == CharacterActive.Mother;
        }
    }
}