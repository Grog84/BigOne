using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.1523567f, 0.02443774f, 0.8308824f)]
[TrackClipType(typeof(AnimationTriggerGuardClip))]
[TrackBindingType(typeof(Animator))]
public class AnimationTriggerGuardTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<AnimationTriggerGuardMixerBehaviour>.Create (graph, inputCount);
    }
}
