using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DisableGuardClip : PlayableAsset, ITimelineClipAsset
{
    public DisableGuardsBehaviour template = new DisableGuardsBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DisableGuardsBehaviour>.Create (graph, template);
        DisableGuardsBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
