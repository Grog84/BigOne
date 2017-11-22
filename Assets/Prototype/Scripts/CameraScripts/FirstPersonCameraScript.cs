﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonCameraScript : CameraScript {


    CinemachineVirtualCamera myCamera;
    public float yAngleMin = -40.0F;
    public float yAngleMax = 70.0F;
    private Transform myTransform;
    private Transform myFollow;
    private CameraScript mainCam;
   
    private void Start()
    {
        mainCam = Camera.main.GetComponent<CameraScript>();
        this.minCamDistance = mainCam.minCamDistance;
        this.maxDistance = mainCam.maxDistance;
      
        myTransform = GetComponent<Transform>();
        myCamera = GetComponent<CinemachineVirtualCamera>();
        SwitchLookAt();
    }

    private void Update()
    {
        myTransform.position = myFollow.position;

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
            StartCoroutine(ResetCameraPriority());
            myFollow = boyLookAtByTag;
        }
        else if ((int)GMController.instance.isCharacterPlaying == 1)
        {
            StartCoroutine(ResetCameraPriority());
            myFollow = motherLookAtByTag;
        }
    }

}
