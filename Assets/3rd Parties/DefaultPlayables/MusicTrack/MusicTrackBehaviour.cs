using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using AI;

[Serializable]
public class MusicTrackBehaviour : PlayableBehaviour
{
    public bool forTheLolis = false;
    [HideInInspector]public bool musicPlayed;
    [HideInInspector] public FMOD.Studio.Bus Music;
    [HideInInspector] public FMOD.Studio.Bus SFX;
    //public Guard selectedGuard;

    public override void OnGraphStart (Playable playable)
    {
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        musicPlayed = false;
    }
}
