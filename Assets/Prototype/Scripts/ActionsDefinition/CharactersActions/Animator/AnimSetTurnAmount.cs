using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetTurnAmount")]
    public class AnimSetTurnAmount : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            SetTurnAmount(controller);
        }

        private void SetTurnAmount(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetFloat("Turn", controller.m_CharacterController.m_TurnAmount, 0.1f, Time.deltaTime);
        }
    }
}
