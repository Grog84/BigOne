﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/BalanceBoard")]
    public class BalanceBoardAction : _Action
    {
        float movement;
        float angleSign = 1f;

        public override void Execute(CharacterStateController controller)
        {
            Balance(controller);
        }

        private void Balance(CharacterStateController controller)
        {
   
                if (Input.GetAxis("Vertical") != 0)
                {
                    movement = Input.GetAxis("Vertical");
                }
                else
                {
                    movement = 0;
                }

                if (Vector3.Angle(controller.m_CharacterController.CharacterTransform.forward, controller.m_CharacterController.m_Camera.forward) <= 90)
                    angleSign = 1f;
                else
                    angleSign = -1f;


            controller.m_CharacterController.m_CharController.Move(controller.m_CharacterController.forwardBalance.transform.forward *(movement*angleSign) * controller.characterStats.m_BalanceMovementSpeed * Time.deltaTime);

            
           

            // Animator
            controller.m_CharacterController.m_ForwardAmount = movement * angleSign;

        }
    }
}
