using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/LoadCheckPoint")]
    public class LoadCheckPoint : _Action
    {

        public override void Execute(GMStateController controller)
        {
            LoadChkPt(controller);
        }

        private void LoadChkPt(GMStateController controller)
        {
            controller.m_GM.LoadCheckpoint();
        }
    }
}
