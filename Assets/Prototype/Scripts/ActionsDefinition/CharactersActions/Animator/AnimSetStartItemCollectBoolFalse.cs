using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/DeactivateStartItemCollect")]
    public class AnimSetStartItemCollectBoolFalse : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            UpdateAnimatorForStartItemCollect(controller);
        }

        private void UpdateAnimatorForStartItemCollect(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetBool("isCollecting", false);
        }
    }
}
