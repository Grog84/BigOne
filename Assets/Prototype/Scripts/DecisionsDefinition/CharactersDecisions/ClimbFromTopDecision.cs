using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/ClimbFromTopDecision")]
public class ClimbFromTopDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isClimbing = CheckIfClimbingFromTopDecision(controller);
        return isClimbing;
    }

    private bool CheckIfClimbingFromTopDecision(CharacterStateController controller)
    {
        if (controller.m_CharacterController.isInClimbArea && controller.m_CharacterController.climbingTop && Input.GetKeyDown(KeyCode.E))
        {

            return true;


        }
        else
        {
            return false;
        }
       
    }


}
