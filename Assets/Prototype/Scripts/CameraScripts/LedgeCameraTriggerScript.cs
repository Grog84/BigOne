using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LedgeCameraTriggerScript : CameraScript
{
    protected CinemachineVirtualCamera cam;
    private Transform camPosition;
    public int priorityAmount = 0;
    private CameraScript mainCam;
    private Vector3 myForward;

    private void Start()
    {
        myForward = transform.parent.forward;
        mainCam = Camera.main.GetComponent<CameraScript>();
        cam = GetComponentInChildren<CinemachineVirtualCamera>();
        camPosition = transform.GetChild(2);
    }

    private void Update()
    {
        if (cam.m_LookAt != null)
        {
            camPosition.position = cam.m_LookAt.position + (myForward * -mainCam.maxDistance);          
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.name == "Boy" && (int)GMController.instance.isCharacterPlaying == 0)
            {
                cam.m_LookAt = mainCam.boyLookAtByTag;
                cam.m_Priority = priorityAmount;
                mainCam.activatedByTrigger = true;
            }
            else if (other.name == "Mother" && (int)GMController.instance.isCharacterPlaying == 1)
            {
                cam.m_LookAt = mainCam.motherLookAtByTag;
                cam.m_Priority = priorityAmount;
                mainCam.activatedByTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.name == "Boy" && (int)GMController.instance.isCharacterPlaying == 0)
            {
                cam.m_LookAt = null;
                cam.m_Priority = 0;
                mainCam.activatedByTrigger = false;
                mainCam.boyInTrigger = false;
            }
            else if (other.name == "Mother" && (int)GMController.instance.isCharacterPlaying == 1)
            {
                cam.m_LookAt = null;
                cam.m_Priority = 0;
                mainCam.activatedByTrigger = false;
                mainCam.boyInTrigger = false;
            }
        }
    }
}
