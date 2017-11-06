using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class AnimationTriggerGuardClip : PlayableAsset, ITimelineClipAsset
{
    public AnimationTriggerGuardBehaviour template = new AnimationTriggerGuardBehaviour ();
    public ExposedReference<Animator> Guard;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<AnimationTriggerGuardBehaviour>.Create (graph, template);
        AnimationTriggerGuardBehaviour clone = playable.GetBehaviour ();
        clone.Guard = Guard.Resolve (graph.GetResolver ());
        return playable;
    }
}
