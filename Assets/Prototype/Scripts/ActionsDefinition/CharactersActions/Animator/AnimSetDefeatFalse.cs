﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/DeactivateDefeat")]
    public class AnimSetDefeatFalse : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForDefeat(controller);
        }

        private void UpdateAnimatorForDefeat(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isDead", false);
            //Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isDead"));
        }

    }
}
