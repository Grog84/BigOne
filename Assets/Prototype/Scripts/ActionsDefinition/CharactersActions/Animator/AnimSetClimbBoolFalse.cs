using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateClimb")]
public class AnimSetClimbBoolFalse : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForClimb(controller);
    }

    private void UpdateAnimatorForClimb(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetBool("isClimbing", false);
        //Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isClimbing"));
    }
}
