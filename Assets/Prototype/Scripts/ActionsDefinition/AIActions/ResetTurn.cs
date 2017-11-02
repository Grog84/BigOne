using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/ResetTurn")]
    public class ResetTurn : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            Resetm_Turn(controller);
        }

        private void Resetm_Turn(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_TurnAmount = 0;
           
        }

    }
    
}
