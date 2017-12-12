using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using DG.Tweening;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/GMActions/ResetGuardsBlackboard")]
    public class ResetGuardsBlackboard : _Action
    {

        public override void Execute(GMStateController controller)
        {
            ResetGuardsBb(controller);
        }

        private void ResetGuardsBb(GMStateController controller)
        {
            controller.m_GM.ResetGuardsBlackBoard();
        }
    }
}