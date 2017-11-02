using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/SetCheckNavPointFalse")]
    public class SetCheckNavPointFalse : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            CheckNavpointFalse(controller);
        }

        private void CheckNavpointFalse(EnemiesAIStateController controller)
        {
            controller.m_AgentController.isCheckingNavPoint = false;

        }

    }
    
}
