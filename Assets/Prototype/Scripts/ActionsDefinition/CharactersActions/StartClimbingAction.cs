using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/StartClimbingAction")]
    public class StartClimbingAction : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            StartClimb(controller);
        }

        private void StartClimb(CharacterStateController controller)
        {
            if (controller.m_CharacterController.climbingTop)
            {
                controller.m_CharacterController.climbAnchorTop = controller.m_CharacterController.climbCollider.transform.parent.transform.GetChild(2);
                Debug.Log("Scendo");
                controller.m_CharacterController.startClimbAnimationTop = true;
            }
            else if (controller.m_CharacterController.climbingBottom)
            {
                controller.m_CharacterController.climbAnchorBottom = controller.m_CharacterController.climbCollider.transform.parent.transform.GetChild(3);
                Debug.Log("Salgo");
                controller.m_CharacterController.startClimbAnimationBottom = true;
            }
        }

    }
}
