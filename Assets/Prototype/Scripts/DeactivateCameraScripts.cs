using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class DeactivateCameraScripts: MonoBehaviour {

    public CameraScript cameraScript;

    public void Activate()
    {
        cameraScript.enabled = true;
    }

    public void Deactivate()
    {
        cameraScript.enabled = false;
    }

}
