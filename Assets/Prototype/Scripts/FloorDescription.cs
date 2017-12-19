using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/FloorStats")]
[System.Serializable]
public class FloorDescription : ScriptableObject {

    public string floorName;

    [Header("AI Perception Parameters")]
    [Range(0.2f, 4.0f)]
    public float noiseStepMultilplier=1.0f;

    [Space]
    [Header("FMOD Sound Emission Parameters")]
    [Range(0, 1f)]
    public float Dirt;
    [Space]
    [Range(0, 1f)]
    public float ReverbLevel;
    [Range(0, 1f)]
    public float ReverbDiffusion;
    [Range(0, 1f)]
    public float ReverbTime;
    [Space]
    [Range(0, 1f)]
    public float HiCutEQ_Walks;
    [Range(0, 1f)]
    public float LowCutEQ_Walks;

}
