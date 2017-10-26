using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/IsBoy")]
    public class IsBoy : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            return GMController.instance.isCharacterPlaying == CharacterActive.Boy;
        }
    }
}
