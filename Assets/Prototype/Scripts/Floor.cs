using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public FloorDescription floorDescription;

    private string lastFloorName = "Normal";

    FootstepsParameters footstepsParameters;

    public float GetNoiseMultiplier()
    {
        return floorDescription.noiseStepMultilplier;
    }

    public FootstepsParameters GetFloorParameters()
    {
        footstepsParameters.Dirt = floorDescription.Dirt;

        footstepsParameters.ReverbLevel = floorDescription.ReverbLevel;
        footstepsParameters.ReverbDiffusion = floorDescription.ReverbDiffusion;
        footstepsParameters.ReverbTime = floorDescription.ReverbTime;

        footstepsParameters.HiCutEQ_Walks = floorDescription.HiCutEQ_Walks;
        footstepsParameters.LowCutEQ_Walks = floorDescription.LowCutEQ_Walks;

        return footstepsParameters;
    }

    public string GetFloorName()
    {
        return floorDescription.floorName;
    }


}
