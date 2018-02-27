using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using AI;

[Serializable]
public class SetGuardDistractedBehaviour : PlayableBehaviour
{
    [HideInInspector]public bool guardDisabled;
    //public Guard selectedGuard;
    public bool disableGuard = false;

    public override void OnGraphStart (Playable playable)
    {
        guardDisabled = false;
    }
}
