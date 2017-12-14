using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/IKGrounderActivateWeight")]
    public class IKGrounderActivateWeight : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            EndClimb(controller);
        }

        private void EndClimb(CharacterStateController controller)
        {
            if (controller.m_CharacterController.climbingTop)
            {
                controller.m_CharacterController.playerGrounderIK.weight = 1f;
            }
        }
    }
}
