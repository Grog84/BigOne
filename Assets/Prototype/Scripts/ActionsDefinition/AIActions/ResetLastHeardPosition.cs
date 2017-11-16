using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/ResetLastHeardPosition")]
    public class ResetLastHeardPosition : _Action
    {
        public override void Execute(EnemiesAIStateController controller)
        {
            ResetPos(controller);
        }

        private void ResetPos(EnemiesAIStateController controller)
        {
            if (GMController.instance.alarmedGuards == 0 && GMController.instance.curiousGuards == 0)
                GMController.instance.ResetPlayerLastHeardPosition();
        }
    }
}
