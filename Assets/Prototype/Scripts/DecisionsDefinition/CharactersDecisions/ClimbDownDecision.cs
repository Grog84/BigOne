﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/ClimbDownDecision")]
public class ClimbDownDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isClimbing = CheckIfClimbingDown(controller);
        return isClimbing;
    }

    private bool CheckIfClimbingDown(CharacterStateController controller)
    {
       // Debug.Log(controller.m_CharacterController.isInClimbArea + " " + controller.m_CharacterController.climbingTop + " " + Input.GetKeyDown(KeyCode.E));
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
