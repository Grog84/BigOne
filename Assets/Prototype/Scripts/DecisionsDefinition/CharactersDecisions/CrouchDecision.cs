using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/Crouch")]
public class CrouchDecision : Decision {

    public override bool Decide(StateController controller)
    {
         return Input.GetKeyDown(KeyCode.C);
    }

}
