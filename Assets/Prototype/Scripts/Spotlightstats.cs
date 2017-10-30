using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/SpotLightsStats")]
public class Spotlightstats : ScriptableObject {

    [Range(0.1f, 10.0f)]
    public float LightRange;
    [Range(0,1)]
    public float intensity;
    public Color LightColor;
}
