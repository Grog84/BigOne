using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetForwardMovement")]
public class AnimSetForwardMovement : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        SetForwardAmount(controller);
    }

    private void SetForwardAmount(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetFloat("Forward", Mathf.Clamp(controller.m_CharacterController.m_ForwardAmount, 0f, 0.5f), 0.1f, Time.deltaTime);
       // controller.m_CharacterController.m_Animator.SetFloat("Turn", controller.m_CharacterController.m_TurnAmount, 0.1f, Time.deltaTime);
    }
}
