using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;

[Serializable]
public class NavAgentStatsBehaviour : PlayableBehaviour
{
    public float speed;
    public float acceleration;
    public float angularSpeed;
}
