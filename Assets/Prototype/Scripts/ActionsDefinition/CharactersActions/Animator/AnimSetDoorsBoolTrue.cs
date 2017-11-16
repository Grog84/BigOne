using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Animator/ActivateDoors")]
    public class AnimSetDoorsBoolTrue : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForDoors(controller);
        }

        private void UpdateAnimatorForDoors(CharacterStateController controller)
        {
            // Check if player has the key
            if (!controller.m_CharacterController.doorObject.transform.GetComponentInChildren<Doors>().hasKey)
            {
                controller.m_CharacterController.m_Animator.SetBool("isLocked", true);
            }
            else
            {
                controller.m_CharacterController.m_Animator.SetBool("isOpening", true);
            }
        }
    }
}
