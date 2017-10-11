using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/ConeStats")]
public class ConeStats : ScriptableObject {

    [Range(0.5f, 10f)]
    public float scaleX=1f;
    [Range(0.5f, 10f)]
    public float scaleY=1f;
    [Range(0.5f, 10f)]
    public float scaleZ=1f;

}
