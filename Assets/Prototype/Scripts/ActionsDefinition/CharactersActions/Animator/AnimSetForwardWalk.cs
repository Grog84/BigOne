using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetForwardWalk")]
public class AnimSetForwardWalk : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        SetForwardAmount(controller);
    }

    private void SetForwardAmount(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetFloat("Forward", Mathf.Clamp(controller.m_CharacterController.m_ForwardAmount, 0f, 0.5f), 0.1f, Time.deltaTime);
    }
}
