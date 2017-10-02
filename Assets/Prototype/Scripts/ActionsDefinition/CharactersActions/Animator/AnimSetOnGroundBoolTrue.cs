using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivateNormal")]
public class AnimSetOnGroundBoolTrue : _Action
{

    public override void Execute(StateController controller)
    {
        UpdateAnimatorForGround(controller);
    }

    private void UpdateAnimatorForGround(StateController controller)
    {
        controller.characterObj.m_Animator.SetBool("OnGround", true);
    }
}
