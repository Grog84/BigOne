using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/EndClimbAction")]
public class EndClimbingAction : _Action
{


    public override void Execute(CharacterStateController controller)
    {
        EndClimb(controller);
    }

    private void EndClimb(CharacterStateController controller)
    {
        if (controller.m_CharacterController.climbingTop)
        {
             //Vector3 pos = new Vector3(controller.m_CharacterController.charDepth, controller.m_CharacterController.charSize, 0);
            // controller.m_CharacterController.CharacterTansform.Translate(pos);
            controller.m_CharacterController.endClimbAnchor = controller.m_CharacterController.climbCollider.transform.parent.transform.GetChild(4);
            controller.m_CharacterController.CharacterTansform.DOMove(controller.m_CharacterController.endClimbAnchor.position, 1f);
        }
    }
}
