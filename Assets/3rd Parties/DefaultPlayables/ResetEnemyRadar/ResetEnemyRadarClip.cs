using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class ResetEnemyRadarClip : PlayableAsset, ITimelineClipAsset
{
    public ResetEnemyRadarBehaviour template = new ResetEnemyRadarBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<ResetEnemyRadarBehaviour>.Create (graph, template);
        ResetEnemyRadarBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
