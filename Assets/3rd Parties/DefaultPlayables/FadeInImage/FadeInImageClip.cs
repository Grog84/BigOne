using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class FadeInImageClip : PlayableAsset, ITimelineClipAsset
{
    public FadeInImageBehaviour template = new FadeInImageBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<FadeInImageBehaviour>.Create (graph, template);
        return playable;
    }
}
