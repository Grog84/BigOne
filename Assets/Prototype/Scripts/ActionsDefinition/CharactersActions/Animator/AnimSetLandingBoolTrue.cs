using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/ActivateLanding")]
public class AnimSetLandingBoolTrue : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForLanding(controller);
    }

    private void UpdateAnimatorForLanding(CharacterStateController controller)
    {

          controller.m_CharacterController.m_Animator.SetBool("isLanding", true);


    }
}
