using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using DG.Tweening;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/FadeOut")]
    public class FadeOut : _Action
    {

        public override void Execute(GMStateController controller)
        {
            StartFadeOut(controller);
        }

        private void StartFadeOut(GMStateController controller)
        {
            controller.m_GM.fadeEffect.DOFade(1, controller.m_GM.fadeOutTime);
        }
    }
}
