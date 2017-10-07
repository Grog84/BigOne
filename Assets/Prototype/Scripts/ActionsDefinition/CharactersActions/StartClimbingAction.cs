using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/StartClimbingAction")]
public class StartClimbingAction : _Action
{


    public override void Execute(CharacterStateController controller)
    {
        StartClimb(controller);
    }

    private void StartClimb(CharacterStateController controller)
    {
        if (controller.m_CharacterController.climbingTop)
        {
            controller.m_CharacterController.climbAnchorTop = controller.m_CharacterController.climbCollider.transform.parent.transform.GetChild(2);
            
            controller.m_CharacterController.CharacterTansform.position = controller.m_CharacterController.climbAnchorTop.position;
        }
        else
        {
            controller.m_CharacterController.climbAnchorBottom = controller.m_CharacterController.climbCollider.transform.parent.transform.GetChild(3);

            controller.m_CharacterController.CharacterTansform.position = controller.m_CharacterController.climbAnchorBottom.position;
        }
    }
}
