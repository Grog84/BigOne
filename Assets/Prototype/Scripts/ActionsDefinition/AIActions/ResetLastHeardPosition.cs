using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/ResetLastHeardPosition")]
    public class ResetLastHeardPosition : _Action
    {
        public override void Execute(EnemiesAIStateController controller)
        {
            ResetPos(controller);
        }

        private void ResetPos(EnemiesAIStateController controller)
        {
            if (GMController.instance.alarmedGuards == 0 && GMController.instance.suspiciousGuards == 0)
                GMController.instance.ResetPlayerLastHeardPosition();
        }
    }
}
