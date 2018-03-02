using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SetGuardDistractedClip : PlayableAsset, ITimelineClipAsset
{
    public SetGuardDistractedBehaviour template = new SetGuardDistractedBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SetGuardDistractedBehaviour>.Create (graph, template);
        SetGuardDistractedBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
