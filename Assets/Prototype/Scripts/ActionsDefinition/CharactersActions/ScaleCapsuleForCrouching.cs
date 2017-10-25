using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/StateEnter/ScaleCapsuleForCrouching")]
    public class ScaleCapsuleForCrouching : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            ScaleCapsule(controller);
        }


        void ScaleCapsule(CharacterStateController controller)
        {

            controller.m_CharacterController.m_CharController.height = controller.characterStats.crouchedColliderHeightDimension;
            controller.m_CharacterController.m_CharController.center = new Vector3(0, controller.characterStats.crouchedColliderYOffset, 0);

        }
    }
}
