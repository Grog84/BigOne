using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetJumpAmount")]
public class AnimSetJumpAmount : _Action
{

    public override void Execute(StateController controller)
    {
        SetJumpAmount(controller);
    }

    private void SetJumpAmount(StateController controller)
    {
        controller.characterObj.m_Animator.SetFloat("Jump", controller.characterObj.m_Rigidbody.velocity.y);
    }
}
