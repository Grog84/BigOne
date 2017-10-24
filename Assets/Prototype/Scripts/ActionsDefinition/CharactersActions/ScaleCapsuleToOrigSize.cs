using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/StateExit/ScaleCapsuleFromCrouching")]
    public class ScaleCapsuleToOrigSize : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            ScaleCapsule(controller);
        }


        void ScaleCapsule(CharacterStateController controller)
        {

            controller.m_CharacterController.m_Capsule.height = controller.m_CharacterController.m_Capsule.height * 2f;
            controller.m_CharacterController.m_Capsule.center = controller.m_CharacterController.m_Capsule.center * 2f;

        }
    }
}
