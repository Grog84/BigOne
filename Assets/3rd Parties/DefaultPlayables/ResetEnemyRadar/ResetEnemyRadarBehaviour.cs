using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using AI;

[Serializable]
public class ResetEnemyRadarBehaviour : PlayableBehaviour
{
    [HideInInspector]public bool radarReset;
    //public Guard selectedGuard;
    

    public override void OnGraphStart (Playable playable)
    {
        radarReset = false;
    }
}
