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

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.name == "Boy" && (int)GMController.instance.isCharacterPlaying == 0)
            {
                firstPersonCamera.m_Priority = 100;
                mainCamera.activatedByTrigger = true;
                mainCamera.boyInTrigger = true;
            }
            else if (other.name == "Mother" && (int)GMController.instance.isCharacterPlaying == 1)
            {
                firstPersonCamera.m_Priority = 100;
                mainCamera.activatedByTrigger = true;
                mainCamera.motherInTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.name == "Boy" && (int)GMController.instance.isCharacterPlaying == 0)
            {
                firstPersonCamera.m_Priority = 0;
                mainCamera.activatedByTrigger = false;
                mainCamera.boyInTrigger = false;
            }
            else if (other.name == "Mother" && (int)GMController.instance.isCharacterPlaying == 1)
            {
                firstPersonCamera.m_Priority = 0;
                mainCamera.activatedByTrigger = false;
                mainCamera.motherInTrigger = false;
            }
        }
    }
}
