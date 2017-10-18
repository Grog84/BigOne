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
<<<<<<< HEAD
       
         if (controller.m_CharacterController.isInPushArea && controller.m_CharacterController.isPushDirectionRight && Input.GetKeyDown(KeyCode.E))
         {
=======
        if (controller.m_CharacterController.isInPushArea && controller.m_CharacterController.isPushDirectionRight && Input.GetKeyDown(KeyCode.E))
        {
>>>>>>> origin/master

            return true;


<<<<<<< HEAD
         }
         else
         {
                return false;
         }
        
        
=======
        }
        else
        {
            return false;
        }

>>>>>>> origin/master
    }


}
