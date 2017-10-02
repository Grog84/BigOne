using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetTurnAmount")]
public class AnimSetTurnAmount : _Action
{

    public override void Execute(StateController controller)
    {
        SetTurnAmount(controller);
    }

    private void SetTurnAmount(StateController controller)
    {
        controller.characterObj.m_Animator.SetFloat("Turn", controller.m_CharacterController.m_TurnAmount, 0.1f, Time.deltaTime);
    }
}
