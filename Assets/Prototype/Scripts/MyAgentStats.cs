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

    [Space(10)]
    [Header("Perception Parameters")]
    public float fillingSpeed = 100.0f;
    public float torsoMultiplier = 10.0f;
    public float noSeeMultiplier = 0.3f;
    [Space(10)]
    public float localSearchRange = 10f;
    public float localSearchTime = 10f;

}
