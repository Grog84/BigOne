using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/CheckForGameActiveMother")]
    public class Ch_CheckGameActiveDecision_Mother : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            return GMController.instance.GetGameStatus() && GMController.instance.isCharacterPlaying == CharacterActive.Mother;
        }
    }
}