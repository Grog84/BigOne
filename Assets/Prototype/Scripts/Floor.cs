using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public FloorDescription floorDescription;

    public float GetNoiseMultiplier()
    {
        return floorDescription.noiseMultilplier;
    }
}
