using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivateNormal")]
public class AnimSetOnGroundBoolTrue : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForGround(controller);
    }

    private void UpdateAnimatorForGround(CharacterStateController controller)
    {
        controller.characterObj.m_Animator.SetBool("OnGround", true);
    }
}
