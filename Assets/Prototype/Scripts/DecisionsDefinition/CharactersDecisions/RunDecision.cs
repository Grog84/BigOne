using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/Run")]
public class RunDecision : Decision {

    public override bool Decide(StateController controller)
    {
         return Input.GetKeyDown(KeyCode.LeftShift);
    }

}
