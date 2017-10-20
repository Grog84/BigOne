using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/Animator/ActivatePursuit")]
public class AnimSetpursuitBoolTrue : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForStartPursuit(controller);
    }

    private void UpdateAnimatorForStartPursuit(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetBool("isChasing", true);

    }
}
