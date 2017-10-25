using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/DeactivateGame")]
    public class DeactivateGame : _Action
    {

        public override void Execute(GMStateController controller)
        {
            Deactivate(controller);
        }

        private void Deactivate(GMStateController controller)
        {
            controller.m_GM.SetActive(false);
        }
    }
}