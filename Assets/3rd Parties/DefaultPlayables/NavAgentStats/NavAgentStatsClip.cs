using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class NavAgentStatsClip : PlayableAsset, ITimelineClipAsset
{
    public NavAgentStatsBehaviour template = new NavAgentStatsBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<NavAgentStatsBehaviour>.Create (graph, template);
        return playable;
    }
}
