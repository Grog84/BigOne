using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/SetHasHeardFalse")]
    public class SetHasHeardFalse : _Action
    {
        public override void Execute(EnemiesAIStateController controller)
        {
            SetHeardFalse(controller);
        }

        private void SetHeardFalse(EnemiesAIStateController controller)
        {
            controller.m_AgentController.hasHeardPlayer = false;
        }
    }
    
}
