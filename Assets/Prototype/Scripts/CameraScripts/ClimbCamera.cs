using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StateMachine;
using DG.Tweening;

public class ClimbCamera : CameraScript
{
    public float yAngleMin = -40.0F;
    public float yAngleMax = 70.0F;
    protected CinemachineVirtualCamera cam;
    private CameraScript mainCam;
    protected CharacterStateController controllerBoy;
    public float blendAmount;
    public int xAngleMax = 45;
    private Vector3 cameraProjection;
    private Vector3 cameraProjectionDir;
    
    public void Start()
    {
        mainCam = Camera.main.GetComponent<CameraScript>();
        this.minCamDistance = mainCam.minCamDistance;
        this.maxDistance = mainCam.maxDistance;
        SwitchLookAt();
        camTransform = transform;
        cam = this.GetComponent<CinemachineVirtualCamera>();
        cam.m_Lens.NearClipPlane = nearClipPlaneDistance;
        camTransform.forward = boyLookAt.forward;
        camTransform.position = boyLookAt.position + (-boyLookAt.forward * maxDistance);
        controllerBoy = boyLookAt.GetComponent<CharacterStateController>();
    }

    private void Update()
    {
        //Debug.Log("Angolo" + Vector3.Angle(boyLookAt.forward, cameraProjectionDir));
        //Debug.Log("Dot:" + Vector3.Dot(boyLookAt.right, camTransform.forward));
        //Debug.Log("currentX" + currentX);

        cameraProjection = new Vector3(camTransform.position.x, boyLookAt.position.y, camTransform.position.z);
        cameraProjectionDir = (boyLookAt.position - cameraProjection).normalized;

        if (controllerBoy.currentState.name == "Climbing")
        { 
            cam.m_Priority = 150;
            if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) <= xAngleMax)
            {
                CamMovement();
            }
            else if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) > xAngleMax && Vector3.Dot(boyLookAt.right, camTransform.forward) < 0)
            {
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Joystick X") > 0)
                {
                    currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
                    currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
                }
                currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
                currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
                currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
            }
            else if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) > xAngleMax && Vector3.Dot(boyLookAt.right, camTransform.forward) > 0)
            {
                if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Joystick X") < 0)
                {
                    currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
                    currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
                }
                currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
                currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
                currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
            }
        }
        else
        {
            cam.m_Priority = 0;
            if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) <= xAngleMax)
            {
                CamMovement();
            }
            else if(Vector3.Angle(boyLookAt.forward, cameraProjectionDir) > xAngleMax && Vector3.Dot(boyLookAt.right,camTransform.forward) < 0)
            {
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Joystick X") > 0)
                {
                    currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
                    currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
                }
                currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
                currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
                currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
            }
            else if(Vector3.Angle(boyLookAt.forward, cameraProjectionDir) > xAngleMax && Vector3.Dot(boyLookAt.right, camTransform.forward) > 0)
            {
                if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Joystick X") < 0)
                {
                    currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
                    currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
                }
                currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
                currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
                currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
            }

        }

        dir.Set(0, 0, -distance);
        camTransform.position = lookAt.position + rotation * dir;
        rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.LookAt(lookAt.position);
    }

    private void CamMovement()
    {
        currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
        currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
        currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
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