using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/FloorStats")]
public class FloorDescription : ScriptableObject {

    [Range(0.2f, 2.0f)]
    public float noiseMultilplier=1.0f;
}
