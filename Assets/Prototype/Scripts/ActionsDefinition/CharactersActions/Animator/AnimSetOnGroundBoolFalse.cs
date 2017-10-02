using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateNormal")]
public class AnimSetOnGroundBoolFalse: _Action
{

    public override void Execute(StateController controller)
    {
        UpdateAnimatorForGround(controller);
    }

    private void UpdateAnimatorForGround(StateController controller)
    {
        controller.characterObj.m_Animator.SetBool("OnGround", false);
    }
}
