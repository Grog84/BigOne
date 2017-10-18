using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetForwardClimb")]
public class AnimSetForwardClimb: _Action
{

    public override void Execute(CharacterStateController controller)
    {
        SetForwardAmount(controller);
    }

    private void SetForwardAmount(CharacterStateController controller)
    {
        if (controller.m_CharacterController.climbingTop)
        {
            controller.m_CharacterController.m_Animator.SetFloat("Forward", Mathf.Clamp(controller.m_CharacterController.m_ForwardAmount, -1f, 0f), 0.1f, Time.deltaTime);
        }
        else if (controller.m_CharacterController.climbingBottom)
        {
            controller.m_CharacterController.m_Animator.SetFloat("Forward", Mathf.Clamp(controller.m_CharacterController.m_ForwardAmount, 0f, 1f), 0.1f, Time.deltaTime);
        }
        else
        {
            controller.m_CharacterController.m_Animator.SetFloat("Forward", controller.m_CharacterController.m_ForwardAmount, 0.1f, Time.deltaTime);
        }
        Debug.Log("Animator" + controller.m_CharacterController.m_Animator.GetFloat("Forward"));
    }
}
