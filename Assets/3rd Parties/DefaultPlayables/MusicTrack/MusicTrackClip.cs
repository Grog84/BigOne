using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class MusicTrackClip : PlayableAsset, ITimelineClipAsset
{
    public MusicTrackBehaviour template = new MusicTrackBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<MusicTrackBehaviour>.Create (graph, template);
        MusicTrackBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
