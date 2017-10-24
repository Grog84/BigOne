using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/GMActions/FadeIn")]
    public class FadeIn : _Action
    {

        public override void Execute(GMStateController controller)
        {
            StartFadeIn(controller);
        }

        private void StartFadeIn(GMStateController controller)
        {

            controller.m_GM.FadeIn();
        }
    }
}