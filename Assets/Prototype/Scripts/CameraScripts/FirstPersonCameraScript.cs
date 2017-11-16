﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonCameraScript : CameraScript {

    CinemachineVirtualCamera myCamera;
    public float yAngleMin = -40.0F;
    public float yAngleMax = 70.0F;

    private void Start()
    {
        myCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {     

        SwitchLookAt();

        // camera movement and limit of movement
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
        rotation = Quaternion.Euler (currentY, currentX, 0);
        transform.rotation = rotation;

    }

    public override void SwitchLookAt()
    {
        if ((int)GMController.instance.isCharacterPlaying == 0)
        {
            myCamera.m_Follow = boyLookAtByTag;
        }
        else if ((int)GMController.instance.isCharacterPlaying == 1)
        {
            myCamera.m_Follow = motherLookAtByTag;
        }
    }

}
