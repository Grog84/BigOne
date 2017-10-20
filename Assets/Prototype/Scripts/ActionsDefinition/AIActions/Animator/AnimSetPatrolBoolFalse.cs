using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/Animator/DeactivatePatrol")]
public class AnimSetPatrolBoolFalse : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForStartPatrol(controller);
    }

    private void UpdateAnimatorForStartPatrol(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetBool("isPatrolling", false);

    }
}
