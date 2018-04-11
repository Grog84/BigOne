using StateMachine;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/DetachClimbableRestart")]
    public class DetachClimbableRestart : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            DetachChild(controller);
        }

        private void DetachChild(CharacterStateController controller)
        {          
            controller.m_CharacterController.climbCollider = null;
            controller.m_CharacterController.isInClimbArea = false;
            controller.m_CharacterController.climbingBottom = false;
            controller.m_CharacterController.isClimbDirectionRight = false;
            controller.m_CharacterController.climbingTop = false;

        }

    }

}
