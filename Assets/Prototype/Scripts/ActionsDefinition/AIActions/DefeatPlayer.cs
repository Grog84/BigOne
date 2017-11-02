using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/DefeatPlayer")]
    public class DefeatPlayer : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            DefeatPlayr(controller);
        }

        private void DefeatPlayr(EnemiesAIStateController controller)
        {
            Debug.Log("Defeat Player");
            controller.characterInterfaces[(int)GMController.instance.isCharacterPlaying].DefeatPlayer();
        }
    }
}
