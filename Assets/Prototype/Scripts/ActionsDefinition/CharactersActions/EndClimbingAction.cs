using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/EndClimbAction")]
    public class EndClimbingAction : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            EndClimb(controller);
        }

        private void EndClimb(CharacterStateController controller)
        {
            if (controller.m_CharacterController.climbingTop)
            {
                controller.m_CharacterController.playerGrounderIK.weight = 0.5f;
                controller.m_CharacterController.endClimbAnchor = controller.m_CharacterController.climbCollider.transform.parent.transform.GetChild(4);
                controller.m_CharacterController.startClimbEnd = true;
                controller.m_CharacterController.startClimbAnimationEnd = true;
            }
        }
    }
}
