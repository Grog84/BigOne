using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AgentStats")]
public class MyAgentStats : ScriptableObject {

    [Header("Motion Parameters")]
    public float speed = 3.0f;
    public float angularSpeed = 180f;
    public float acceleration = 10f;
    public float stoppingDistance = 2f;
    public float spotRotatingSpeed = 3f;

}
