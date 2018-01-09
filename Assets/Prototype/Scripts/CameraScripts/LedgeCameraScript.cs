using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StateMachine;
using DG.Tweening;

public class LedgeCameraScript : CameraScript {

    // max and min angles of the camera movement
    public float yAngleMin = -40.0F;
    public float yAngleMax = 70.0F;
    public float xAngleMin = 20.0f;
    public float xAngleMax = 20.0f;
    public float ledgeSensibilityModifier = 0.1f;
    protected CinemachineVirtualCamera cam;
    private CameraScript mainCam;
    CinemachineTransposer cinemachineTransposer;
    private void Start()
    {
        mainCam = Camera.main.GetComponent<CameraScript>();
        this.minCamDistance = mainCam.minCamDistance;
        this.maxDistance = mainCam.maxDistance;
        //cam.m_Lens.FieldOfView = mainCam.Fov;       
        SwitchLookAt();
        camTransform = transform;
        cam = this.GetComponent<CinemachineVirtualCamera>();
        cinemachineTransposer = cam.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Update()
    {
        // camera movement by axis
        currentX += Input.GetAxis("Mouse X") * (InputManager.instance.MouseXSensitivity * ledgeSensibilityModifier);
        currentX += Input.GetAxis("Joystick X") * (InputManager.instance.JoystickXSensitivity * ledgeSensibilityModifier);
        currentY -= Input.GetAxis("Mouse Y") * (InputManager.instance.MouseYSensitivity * ledgeSensibilityModifier);
        currentY -= Input.GetAxis("Joystick Y") * (InputManager.instance.JoystickYSensitivity * ledgeSensibilityModifier);
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
        currentX = Mathf.Clamp(currentX, xAngleMin, xAngleMax);

        //if (ledge)
        //{
            cinemachineTransposer.m_FollowOffset.z = -currentX;
        //}
        //else
        //{
        //    cinemachineTransposer.m_FollowOffset.x = -currentX;
        //}

        cinemachineTransposer.m_FollowOffset.y = currentY;
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
