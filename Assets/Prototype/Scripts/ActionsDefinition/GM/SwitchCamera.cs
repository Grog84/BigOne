using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/SwitchCamera")]
    public class SwitchCamera : _Action {

        public override void Execute(GMStateController controller)
        {
            Switch(controller);
        }

        private void Switch(GMStateController controller)
        {
            controller.m_GM.m_MainCamera.SwitchLookAt();
        }
    }
}
