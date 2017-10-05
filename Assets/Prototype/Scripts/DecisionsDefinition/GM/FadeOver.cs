using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/GM/FadeOver")]
public class FadeOver : Decision {

    public override bool Decide(GMStateController controller)
    {
        return controller.m_GM.isFadeScreenVisible;
    }
}
