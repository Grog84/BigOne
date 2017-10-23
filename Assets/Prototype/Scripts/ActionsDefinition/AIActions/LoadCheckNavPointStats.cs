using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/AIActions/LoadCheckNavPointStats")]
    public class LoadCheckNavPointStats : _Action
    {

        public override void Execute(EnemiesAIStateController controller)
        {
            LoadCheckNavPoint(controller);
        }

        private void LoadCheckNavPoint(EnemiesAIStateController controller)
        {
            controller.m_AgentController.UpdateStats("checkNavPoint");
        }
    }
}
