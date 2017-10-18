using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/EndExitPushDecision")]
public class EndExitPushDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isPushing = CheckIfEndPushing(controller);
        return isPushing;
    }

    private bool CheckIfEndPushing(CharacterStateController controller)
    {
       
         if (!controller.m_CharacterController.isExitPush)
         {

                return true;


         }
         else
         {
                return false;
         }
        
        
    }


}
