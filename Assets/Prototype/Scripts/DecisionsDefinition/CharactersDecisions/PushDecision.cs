using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/PushDecision")]
public class PushDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isPushing = CheckIfPushing(controller);
        return isPushing;
    }

    private bool CheckIfPushing(CharacterStateController controller)
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
