using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StateMachine;
using DG.Tweening;



public class ThirdPersonCameraScript : CameraScript {

    // max and min angles of the camera movement
    protected float yAngleMin = -40.0F;
    protected float yAngleMax = 70.0F;
    protected CinemachineVirtualCamera cam;
    private CameraScript mainCam;
    protected CharacterStateController controllerBoy;
    //public float currentXLockPositiveAngle = 4000;
    //public float currentXLockNegativeAngle = -4000;
  
    protected void Start()
    {
        mainCam = Camera.main.GetComponent<CameraScript>();
        this.minCamDistance = mainCam.minCamDistance;
        this.maxDistance = mainCam.maxDistance;
        //inputManager = InputManager.instance;
        //cam.m_Lens.FieldOfView = mainCam.Fov;
       
        SwitchLookAt();

        camTransform = transform;
        cam = this.GetComponent<CinemachineVirtualCamera>();
        cam.m_Lens.NearClipPlane = nearClipPlaneDistance;
        controllerBoy = boyLookAt.GetComponent<CharacterStateController>();
        currentX = -lookAt.eulerAngles.y;
    }

    protected void Update()
    {

        // camera movement by axis
        currentX -= Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
        currentX -= Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
        currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);

        Debug.Log(currentX);

        //camera management of the bound to the player, movement, rotation and look direction
        dir.Set(0, 0, -distance);
        camTransform.position = lookAt.position + rotation * dir;
        rotation = Quaternion.Euler(currentY, -currentX, 0);
        camTransform.LookAt(lookAt.position);

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


