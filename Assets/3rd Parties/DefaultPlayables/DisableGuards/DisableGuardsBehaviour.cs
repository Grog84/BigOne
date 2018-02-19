using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DisableGuardsBehaviour : PlayableBehaviour
{
    [HideInInspector]public bool guardDisabled;
    public bool disableGuards = false;

    public override void OnGraphStart (Playable playable)
    {
        guardDisabled = false;
    }
}
