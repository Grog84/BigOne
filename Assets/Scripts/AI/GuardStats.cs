using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/GuardStats")]
public class GuardStats : MyAgentStats {

    [Space(10)]
    [Header("Perception Parameters")]
    public float fillingSpeed = 100.0f;
    public float torsoMultiplier = 10.0f;
    public float noSeeMultiplier = 0.3f;
    [Space(10)]
    public float localSearchRange = 10f;
    public float localSearchTime = 10f;

}
