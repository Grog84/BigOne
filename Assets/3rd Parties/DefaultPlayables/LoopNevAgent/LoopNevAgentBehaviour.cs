using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;

[Serializable]
public class LoopNevAgentBehaviour : PlayableBehaviour
{
    public Transform Destination;
    public NavMeshAgent Agent;

    public override void OnGraphStart (Playable playable)
    {
        
    }
}
