using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/ClimbDecision")]
public class ClimbDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isClimbing = CheckIfClimbing(controller);
        return isClimbing;
    }

    private bool CheckIfClimbing(CharacterStateController controller)
    {
        if()
    }


}
