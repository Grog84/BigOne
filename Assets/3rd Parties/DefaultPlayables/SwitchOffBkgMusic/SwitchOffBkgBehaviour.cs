using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[Serializable]
public class SwitchOffBkgBehaviour : PlayableBehaviour
{
    [HideInInspector] public bool done;

    public override void OnGraphStart (Playable playable)
    {
        done = false;
    }
}
