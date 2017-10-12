using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/Crouch")]
public class CrouchDecision : Decision
{
    bool Crouch = false;

    public override bool Decide(CharacterStateController controller)
    {

        if(Input.GetButtonDown("Crouch") && Crouch == false)
        {
            Crouch = true;
        }
        else if (Input.GetButtonDown("Crouch") && Crouch == true)
        {
            Crouch = false;
        }

        return Crouch;

    }

}
