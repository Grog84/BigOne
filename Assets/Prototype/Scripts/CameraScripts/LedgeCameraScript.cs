using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LedgeCameraScript : CameraScript {

    [HideInInspector] public CinemachineVirtualCamera myCamera;
    private Transform myTransform;
    CameraScript mainCam;


    private void Start()
    {
        mainCam = Camera.main.GetComponent<CameraScript>();
        myTransform = GetComponent<Transform>();
        myCamera = GetComponent<CinemachineVirtualCamera>();
        SwitchLookAt();
    }

    private void Update()
    {
        
    }

    public override void SwitchLookAt()
    {
        if ((int)GMController.instance.isCharacterPlaying == 0)
        {
            StartCoroutine(ResetCameraPriority());
            myCamera.m_Follow = boyLookAtByTag;
            myCamera.m_LookAt = boyLookAtByTag;
        }
        else if ((int)GMController.instance.isCharacterPlaying == 1)
        {
            StartCoroutine(ResetCameraPriority());
            myCamera.m_Follow = motherLookAtByTag;
            myCamera.m_LookAt = motherLookAtByTag;
        }
    }

}
