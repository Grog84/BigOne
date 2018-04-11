using StateMachine;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/DetachPushableRestart")]
    public class DetachPushableRestart : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            DetachChild(controller);
        }

        private void DetachChild(CharacterStateController controller)
        {
            
            controller.m_CharacterController.pushCollider = null;
            controller.m_CharacterController.isInPushArea = false;
            controller.m_CharacterController.isPushDirectionRight = false;
            
        }
        
    }

}
