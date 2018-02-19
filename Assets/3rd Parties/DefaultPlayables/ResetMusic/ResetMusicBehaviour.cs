using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class ResetMusicBehaviour : PlayableBehaviour
{
    [HideInInspector] public bool musicReset;

    public override void OnGraphStart (Playable playable)
    {
        musicReset = false;
    }
}
