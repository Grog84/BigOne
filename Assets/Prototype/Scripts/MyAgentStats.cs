using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AgentStats")]
public class MyAgentStats : ScriptableObject {

    // Steering
    public float speed = 3.0f;
    public float angularSpeed = 180f;
    public float acceleration = 10f;
    public float stoppingDistance = 2f;

    public float fillingSpeed = 1.0f;

    public float localSearchRange = 20f;

    public float lookRange = 8f;
    public float lookSphereCastRadius = 0.5f;

}
