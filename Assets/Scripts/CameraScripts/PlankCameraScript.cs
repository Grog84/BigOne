using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StateMachine;
using DG.Tweening;



public class PlankCameraScript : CameraScript {



    // max and min angles of the camera movement
    protected bool isCameraCRDone = true;
    protected bool isCameraCR = false;
    public float yAngleMin = -40.0F;
    public float yAngleMax = 70.0F;
    protected CinemachineVirtualCamera cam;
    private CameraScript mainCam;
    private CharacterStateController currentActivePlayer;
  
    private void Start()
    {
        SwitchLookAt();

        mainCam = Camera.main.GetComponent<CameraScript>();
        this.minCamDistance = mainCam.minCamDistance;
        this.maxDistance = mainCam.maxDistance;
        //inputManager = InputManager.instance;
        //cam.m_Lens.FieldOfView = mainCam.Fov;


        cam = this.GetComponent<CinemachineVirtualCamera>();
        //Cursor.lockState = CursorLockMode.Locked;
        cam.m_Lens.NearClipPlane = nearClipPlaneDistance;
    }

    private void Update()
    {

        // camera movement by axis
        currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
        currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
        currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;

        //baunderies of the camera movement
        if (currentActivePlayer.currentState.name != "BalanceBoard")
        {
            cam.m_Priority = 0;
        }
        else
        {
            cam.m_Priority = 160;
        }

        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);

        //camera management of the bound to the player, movement, rotation and look direction
        dir.Set(0, 0, -distance);
        camTransform.position = lookAt.position + rotation * dir;
        rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.LookAt(lookAt.position);

        
    }
    
    public override void SwitchLookAt()
    {
        if ((int)GMController.instance.isCharacterPlaying == 0)
        {
            currentActivePlayer = boyLookAt.GetComponent<CharacterStateController>();
            StartCoroutine(ResetCameraPriority());
            lookAt = boyLookAtByTag;
        }
        else if ((int)GMController.instance.isCharacterPlaying == 1)
        {
            currentActivePlayer = motherLookAt.GetComponent<CharacterStateController>();
            StartCoroutine(ResetCameraPriority());
            lookAt = motherLookAtByTag;
        }
    }

}
