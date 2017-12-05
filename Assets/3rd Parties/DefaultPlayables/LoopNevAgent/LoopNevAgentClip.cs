using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;

[Serializable]
public class LoopNevAgentClip : PlayableAsset, ITimelineClipAsset
{
    public LoopNevAgentBehaviour template = new LoopNevAgentBehaviour ();
    public ExposedReference<Transform> Destination;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Looping; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<LoopNevAgentBehaviour>.Create (graph, template);
        LoopNevAgentBehaviour clone = playable.GetBehaviour ();
        clone.Destination = Destination.Resolve (graph.GetResolver ());
        return playable;
    }
}
