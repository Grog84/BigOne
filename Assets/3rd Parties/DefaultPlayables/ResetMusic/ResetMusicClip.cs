using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class ResetMusicClip : PlayableAsset, ITimelineClipAsset
{
    public ResetMusicBehaviour template = new ResetMusicBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<ResetMusicBehaviour>.Create (graph, template);
        ResetMusicBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
