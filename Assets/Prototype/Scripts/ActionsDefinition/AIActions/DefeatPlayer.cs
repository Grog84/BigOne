using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/DefeatPlayer")]
    public class DefeatPlayer : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            DefeatPlayr(controller);
        }

        private void DefeatPlayr(EnemiesAIStateController controller)
        {
            GMController.instance.DefeatPlayer();
        }
    }
}
