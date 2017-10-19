﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateFall")]
public class AnimSetFallBoolFalse : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        UpdateAnimatorForFall(controller);
    }

    private void UpdateAnimatorForFall(CharacterStateController controller)
    {
        
            controller.m_CharacterController.m_Animator.SetBool("isFalling", false);



    }
}
