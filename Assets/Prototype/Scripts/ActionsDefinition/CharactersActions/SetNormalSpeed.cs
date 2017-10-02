using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNormalSpeed : _Action {

    public override void Execute(StateController controller)
    {
        SetSpeed(controller);
    }

    private void SetSpeed(StateController controller)
    {
        controller.m_CharacterController.m_MoveSpeedMultiplier = controller.characterStats.m_NormalSpeedMultiplier;
    }
}
