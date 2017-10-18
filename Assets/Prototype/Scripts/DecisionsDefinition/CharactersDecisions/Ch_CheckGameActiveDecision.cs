using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/CheckForGameActive")]
public class Ch_CheckGameActiveDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        return GMController.instance.GetGameStatus();
    }
}