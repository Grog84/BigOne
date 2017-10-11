using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndClimbFallDecision")]
public class EndClimbFallDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isClimbing = CheckIfClimbingFall(controller);
        return isClimbing;
    }

    private bool CheckIfClimbingFall(CharacterStateController controller)
    {
        if (!controller.m_CharacterController.climbingTop && Input.GetKeyDown(KeyCode.E))
        {


            return true;


        }
        else
        {
            return false;
        }

    }


}
