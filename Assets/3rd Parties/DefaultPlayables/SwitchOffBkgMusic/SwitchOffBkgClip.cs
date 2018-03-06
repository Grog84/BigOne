using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SwitchOffBkgClip : PlayableAsset, ITimelineClipAsset
{
    public SwitchOffBkgBehaviour template = new SwitchOffBkgBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SwitchOffBkgBehaviour>.Create (graph, template);
        SwitchOffBkgBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
