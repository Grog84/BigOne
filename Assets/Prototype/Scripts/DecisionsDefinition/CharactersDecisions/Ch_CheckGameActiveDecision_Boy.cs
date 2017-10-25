using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/CheckForGameActiveBoy")]
    public class Ch_CheckGameActiveDecision_Boy: Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            return GMController.instance.GetGameStatus() && GMController.instance.isCharacterPlaying == CharacterActive.Boy;
        }
    }
}