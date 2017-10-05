using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/GMActions/FadeOut")]
public class FadeOut : _Action
{
    public override void Execute(GMStateController controller)
    {
        StartFadeOut(controller);
    }

    private void StartFadeOut(GMStateController controller)
    {
        controller.m_GM.FadeAnim.SetBool("Fade", false);
    }
}
