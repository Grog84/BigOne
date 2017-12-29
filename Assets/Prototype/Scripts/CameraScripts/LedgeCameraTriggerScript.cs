using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LedgeCameraTriggerScript : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    private LedgeCameraScript myCameraScript;
    private Transform camPosition;
    public int priorityAmount = 0;
    private CameraScript mainCam;
    private Vector3 myForward;
    public int childPosition = 0;

    private void Start()
    {
        cam = GetComponentInChildren<CinemachineVirtualCamera>();
        cam.m_LookAt = null;
        myForward = transform.parent.forward;
        myCameraScript = cam.GetComponent<LedgeCameraScript>();
        mainCam = Camera.main.GetComponent<CameraScript>();
        camPosition = transform.GetChild(childPosition);
    }

    private void Update()
    {
        if (cam.m_LookAt != null)
        {
            camPosition.position = cam.m_LookAt.position + (myForward * -myCameraScript.distance);
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
