using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using AI;

[TrackColor(0.855f, 0.8623f, 0.87f)]
[TrackClipType(typeof(SetGuardDistractedClip))]
[TrackBindingType(typeof(Guard))]
public class SetGuardDistractedTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SetGuardDistractedMixerBehaviour>.Create (graph, inputCount);
    }

    public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
    {
#if UNITY_EDITOR
        
#endif
        base.GatherProperties(director, driver);
    }
}
