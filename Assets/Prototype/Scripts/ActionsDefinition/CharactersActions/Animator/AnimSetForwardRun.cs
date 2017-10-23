using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Animator/SetForwardRun")]
    public class AnimSetForwardRun : _Action
    {

<<<<<<< HEAD
        public override void Execute(CharacterStateController controller)
        {
            SetForwardAmount(controller);
        }

        private void SetForwardAmount(CharacterStateController controller)
        {
            controller.m_CharacterController.m_Animator.SetFloat("Forward", controller.m_CharacterController.m_ForwardAmount, 0.1f, Time.deltaTime);
            //Debug.Log(controller.m_CharacterController.m_ForwardAmount);
        }
=======
    private void SetForwardAmount(CharacterStateController controller)
    {
        controller.m_CharacterController.m_Animator.SetFloat("Forward", controller.m_CharacterController.m_ForwardAmount, 0.1f, Time.deltaTime);
        Debug.Log(controller.m_CharacterController.m_ForwardAmount);
>>>>>>> f33a8f5
    }
}
