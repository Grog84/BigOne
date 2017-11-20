using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonCameraTrigger : MonoBehaviour {

    private CameraScript mainCamera;
    public CinemachineVirtualCamera firstPersonCamera;

    private void Awake()
    {
        mainCamera = Camera.main.GetComponent<CameraScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            firstPersonCamera.m_Priority = 100;
            mainCamera.activatedByTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            firstPersonCamera.m_Priority = -10;
            mainCamera.activatedByTrigger = false;
        }
    }
}
