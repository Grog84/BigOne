using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/Animator/DeactivatePursuit")]
public class AnimSetPursuitBoolFalse : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForStartPursuit(controller);
    }

    private void UpdateAnimatorForStartPursuit(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetBool("isChasing", false);

    }
}
