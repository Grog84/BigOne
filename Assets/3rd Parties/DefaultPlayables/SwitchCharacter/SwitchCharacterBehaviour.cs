using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SwitchCharacterBehaviour : PlayableBehaviour
{
    public bool characterSwitched;

    public override void OnGraphStart (Playable playable)
    {
        characterSwitched = false;
    }
}
