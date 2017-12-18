using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StateMachine;
using DG.Tweening;

public class LedgeCameraScript : CameraScript {

    // max and min angles of the camera movement
    protected float yAngleMin = -40.0F;
    protected float yAngleMax = 70.0F;
    protected CinemachineVirtualCamera cam;
    private CameraScript mainCam;    
  
    private void Start()
    {
        mainCam = Camera.main.GetComponent<CameraScript>();
        this.minCamDistance = mainCam.minCamDistance;
        this.maxDistance = mainCam.maxDistance;
        inputManager = InputManager.instance;
        //cam.m_Lens.FieldOfView = mainCam.Fov;
       
        SwitchLookAt();

        camTransform = transform;
        cam = this.GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        // camera movement by axis
        currentX += Input.GetAxis("Mouse X") * inputManager.MouseXSensitivity;
        currentX += Input.GetAxis("Joystick X") * inputManager.JoystickXSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * inputManager.MouseYSensitivity;
        currentY -= Input.GetAxis("Joystick Y") * inputManager.JoystickYSensitivity;
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
    }

    public override void SwitchLookAt()
    {
        if ((int)GMController.instance.isCharacterPlaying == 0)
        {
           
            StartCoroutine(ResetCameraPriority());
            lookAt = boyLookAtByTag;
        }
        else if ((int)GMController.instance.isCharacterPlaying == 1)
        {
            
            StartCoroutine(ResetCameraPriority());
            lookAt = motherLookAtByTag;
        }
    }

}
