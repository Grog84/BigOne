using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/EndPush")]
    public class EndPushAction : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            EndPush(controller);
        }

        private void EndPush(CharacterStateController controller)
        {
            controller.m_CharacterController.isExitPush = true;
            controller.m_CharacterController.isPushLimit = false;
        }
    }
}

