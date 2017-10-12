using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/ClimbTopDecision")]
public class ClimbTopDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isClimbing = CheckIfClimbingTop(controller);
        return isClimbing;
    }

    private bool CheckIfClimbingTop(CharacterStateController controller)
    {
        // Debug.Log(controller.m_CharacterController.isInClimbArea + " " + controller.m_CharacterController.isClimbDirectionRight + " " + Input.GetKeyDown(KeyCode.E));
        if (controller.m_CharacterController.isInClimbArea && controller.m_CharacterController.isClimbDirectionRight && Input.GetKeyDown(KeyCode.E))
        {
            
            return true;
        }
        else
        {
            return false;
        }
       
    }


}
