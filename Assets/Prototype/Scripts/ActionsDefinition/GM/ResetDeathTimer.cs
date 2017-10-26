using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/ResetDeathTimer")]
    public class ResetDeathTimer : _Action
    {

        public override void Execute(GMStateController controller)
        {
            ResetTimer(controller);
        }

        private void ResetTimer(GMStateController controller)
        {
            controller.m_GM.deathTimer = 0f;
        }
    }
}