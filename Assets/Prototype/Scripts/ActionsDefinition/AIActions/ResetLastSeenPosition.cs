using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/ResetLastSeenPosition")]
    public class ResetLastSeenPosition : _Action
    {
        public override void Execute(EnemiesAIStateController controller)
        {
            ResetPos(controller);
        }

        private void ResetPos(EnemiesAIStateController controller)
        {
            GMController.instance.ResetPlayerLastSeenPosition();
        }
    }
}
