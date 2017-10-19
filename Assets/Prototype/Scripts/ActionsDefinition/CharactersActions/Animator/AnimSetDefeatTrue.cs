using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivateDefeat")]
public class AnimSetDefeatTrue : _Action
{
    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForDefeat(controller);
    }

    private void UpdateAnimatorForDefeat(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetBool("isDead", true);
        Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isDead"));
    }

}
