using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SwitchCharacterClip : PlayableAsset, ITimelineClipAsset
{
    public SwitchCharacterBehaviour template = new SwitchCharacterBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SwitchCharacterBehaviour>.Create (graph, template);
        SwitchCharacterBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
