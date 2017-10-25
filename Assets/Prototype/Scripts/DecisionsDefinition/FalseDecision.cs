using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

[CreateAssetMenu(menuName = "Prototype/Decisions/FalseDecision")]
public class FalseDecision : Decision {

    public override bool Decide(CharacterStateController controller) { return false; }

    public override bool Decide(EnemiesAIStateController controller) { return false; }

    public override bool Decide(GMStateController controller) { return false; }
}
