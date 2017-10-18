using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivatePush")]
public class AnimSetPushBoolTrue : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForPush(controller);
    }

    private void UpdateAnimatorForPush(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetBool("isPushing", true);
        Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isPushing"));
    }
}
