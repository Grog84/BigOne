using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateCrouch")]
public class AnimSetCrouchBoolFalse: _Action {

    public override void Execute(StateController controller)
    {
        UpdateAnimatorForCrouch(controller);
    }

    private void UpdateAnimatorForCrouch(StateController controller)
    {
        controller.characterObj.m_Animator.SetBool("Crouch", false);
    }
}
