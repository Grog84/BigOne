using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/AI/CheckForGameActive")]
public class AI_CheckGameActiveDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        return GMController.instance.GetGameStatus();
    }
}
