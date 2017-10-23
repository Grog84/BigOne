﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivatePush")]
    public class AnimSetPushBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForPush(controller);
        }

        private void UpdateAnimatorForPush(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isPushing", false);
            Debug.Log(controller.m_CharacterController.m_Animator.GetBool("isPushing"));
        }
    }
}
