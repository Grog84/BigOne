using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/ActivateRadar")]
    public class ActivateRadar : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            EnableRadar(controller);
        }

        private void EnableRadar(CharacterStateController controller)
        {
            controller.m_CharacterController.CharacterTransform.Find("EnemyClose").gameObject.SetActive(true);      
        }
    }
}
