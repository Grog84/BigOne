using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/SetSaveStatePatrol")]
    public class SetSaveStatePatrol : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            SaveStateUpdate(controller);
        }

        private void SaveStateUpdate(EnemiesAIStateController controller)
        {
            controller.saveState = GuardStates.Patrol;
        }
    }
}
