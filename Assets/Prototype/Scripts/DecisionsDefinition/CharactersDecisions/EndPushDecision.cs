using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndPushDecision")]
public class EndPushDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isPushing = CheckIfEndPushing(controller);
        return isPushing;
    }

    private bool CheckIfEndPushing(CharacterStateController controller)
    {
       
         if (controller.m_CharacterController.isInPushArea && controller.m_CharacterController.isPushDirectionRight && Input.GetKeyDown(KeyCode.E))
         {

                return true;


         }
         else
         {
                return false;
         }
        
        
    }


}
