using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonCameraTrigger : MonoBehaviour {

    public CinemachineVirtualCamera firstPersonCamera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            firstPersonCamera.m_Priority = 100;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            firstPersonCamera.m_Priority = -10;
        }
    }
}
