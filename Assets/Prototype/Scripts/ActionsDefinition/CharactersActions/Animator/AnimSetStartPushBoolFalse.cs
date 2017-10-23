using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateStartPush")]
public class AnimSetStartPushBoolFalse : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForStartPush(controller);
    }

    private void UpdateAnimatorForStartPush(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetBool("isStartingPush", false);
       // Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isStartingPush"));
    }
}
