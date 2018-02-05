using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SwitchSceneClip : PlayableAsset, ITimelineClipAsset
{
    public SwitchSceneBehaviour template = new SwitchSceneBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SwitchSceneBehaviour>.Create (graph, template);
        SwitchSceneBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
