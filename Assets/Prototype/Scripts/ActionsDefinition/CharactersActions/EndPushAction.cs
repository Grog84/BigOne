using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/EndPush")]
    public class EndPushAction : _Action
    {

<<<<<<< HEAD

        public override void Execute(CharacterStateController controller)
        {
            EndPush(controller);
        }

        private void EndPush(CharacterStateController controller)
        {
            controller.m_CharacterController.isExitPush = true;
            controller.m_CharacterController.isPushLimit = false;
        }
=======
    private void EndPush(CharacterStateController controller)
    {
        controller.m_CharacterController.isExitPush = true;  
       
>>>>>>> f33a8f5
    }
}

