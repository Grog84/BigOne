using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;

[TrackColor(0.855f, 0.8623f, 0.87f)]
[TrackClipType(typeof(LoopNevAgentClip))]
public class LoopNevAgentTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<LoopNevAgentMixerBehaviour>.Create (graph, inputCount);
    }
}
