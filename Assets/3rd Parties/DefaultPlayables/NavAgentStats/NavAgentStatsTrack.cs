using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Collections.Generic;
using UnityEngine.AI;

[TrackColor(0f, 0.3578416f, 0.7352941f)]
[TrackClipType(typeof(NavAgentStatsClip))]
[TrackBindingType(typeof(NavMeshAgent))]
public class NavAgentStatsTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<NavAgentStatsMixerBehaviour>.Create (graph, inputCount);
    }

    public override void GatherProperties (PlayableDirector director, IPropertyCollector driver)
    {
#if UNITY_EDITOR
        NavMeshAgent trackBinding = director.GetGenericBinding(this) as NavMeshAgent;
        if (trackBinding == null)
            return;

        var serializedObject = new UnityEditor.SerializedObject (trackBinding);
        var iterator = serializedObject.GetIterator();
        while (iterator.NextVisible(true))
        {
            if (iterator.hasVisibleChildren)
                continue;

            driver.AddFromName<NavMeshAgent>(trackBinding.gameObject, iterator.propertyPath);
        }
#endif
        base.GatherProperties (director, driver);
    }
}
