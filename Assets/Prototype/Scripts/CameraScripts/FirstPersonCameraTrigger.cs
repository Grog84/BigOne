using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonCameraTrigger : MonoBehaviour {

    private FirstPersonCameraScript firstPersonCameraScript;
    public CinemachineVirtualCamera firstPersonCamera;

    private void Awake()
    {
        firstPersonCameraScript = firstPersonCamera.GetComponent<FirstPersonCameraScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            firstPersonCamera.m_Priority = 100;
            firstPersonCameraScript.FPSbyTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            firstPersonCamera.m_Priority = -10;
            firstPersonCameraScript.FPSbyTrigger = false;

        }
    }
}
