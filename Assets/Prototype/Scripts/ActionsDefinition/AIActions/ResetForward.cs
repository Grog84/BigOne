using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/ResetForward")]
    public class ResetForward : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            Resetm_Forward(controller);
        }

        private void Resetm_Forward(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_ForwardAmount = 0;
           
        }

    }
    
}
