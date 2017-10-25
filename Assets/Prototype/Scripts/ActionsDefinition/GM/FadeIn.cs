using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using DG.Tweening;

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
            controller.m_GM.fadeEffect.DOFade(0, controller.m_GM.fadeInTime);
            //StartCoroutine(WaitAndActivate());
            //isFadeScreenVisible = false;

            controller.m_GM.FadeIn();
        }
    }
}