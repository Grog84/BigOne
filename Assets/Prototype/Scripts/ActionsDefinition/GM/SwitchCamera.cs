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

            for (int i = 0; i < GMController.instance.m_MainCamera.Length; i++)
            {
                controller.m_GM.m_MainCamera[i].SwitchLookAt();

            }

        }
    }
}
