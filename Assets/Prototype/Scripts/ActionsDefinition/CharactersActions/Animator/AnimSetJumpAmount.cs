using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetJumpAmount")]
public class AnimSetJumpAmount : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        SetJumpAmount(controller);
    }

    private void SetJumpAmount(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetFloat("Jump", controller.m_CharacterController.m_Rigidbody.velocity.y);
    }
}
