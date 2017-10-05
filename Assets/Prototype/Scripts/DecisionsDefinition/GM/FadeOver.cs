using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOver : Decision {

    public override bool Decide(GMStateController controller)
    {
        
        return controller.m_GM.GetGameStatus();
    }
}
