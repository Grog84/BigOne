using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StateMachine;
using DG.Tweening;
using Character;

public class RestrictedCamera : CameraScript
{
    public float yAngleMin = -40.0F;
    public float yAngleMax = 70.0F;
    protected CinemachineVirtualCamera cam;
    private CameraScript mainCam;
    protected CharacterStateController controllerBoy;
    protected CharacterStateController controllerMother;
    public int xAngleMax = 45;
    // used to calculate the angles between the camera and the player
    private Vector3 cameraProjection;
    private Vector3 cameraProjectionDir;
    //used for not repeating the resetcamera method
    public bool resetCameraPos = false;
    //used to get the referance to the ledge trigger used at the moment
    private _CharacterController boyCharacter;
    private _CharacterController motherCharacter;
    //used to recognize whitch character interacted with the trigger
    bool boyActive = true;

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
        controllerMother = motherLookAt.GetComponent<CharacterStateController>();
        boyCharacter = boyLookAt.GetComponent<_CharacterController>();
        motherCharacter = motherLookAt.GetComponent<_CharacterController>();
    }

    private void Update()
    {
        //Debug.Log("Angolo " + boyCharacter.balanceCollider.transform.eulerAngles.y); 
        //Debug.Log("Dot: " + Vector3.Dot(boyLookAt.right, camTransform.forward));
        //Debug.Log("currentX " + currentX);
        //Debug.Log(boyLookAt.forward); 

        //projection of the camera angle on a 2d plane
        cameraProjection = new Vector3(camTransform.position.x, boyLookAt.position.y, camTransform.position.z);
        cameraProjectionDir = (boyLookAt.position - cameraProjection).normalized;

        if (controllerBoy.currentState.name == "Climbing")
        {
            ResetCameraPosition("Climbing");
            cam.m_Priority = 150;
             
            if (resetCameraPos == true)
            {
                if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) <= xAngleMax)
                {
                    //enabling inputs of the camera
                    CamMovement();
                }
                else if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) > xAngleMax && Vector3.Dot(boyLookAt.right, camTransform.forward) < 0)
                {
                    //restricting the inputs of the camera when reaching the desired angle
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
                    //restricting the inputs of the camera when reaching the desired angle
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
        }   
        else if (controllerBoy.currentState.name == "BalanceLedge" || controllerMother.currentState.name == "BalanceLedge")
        {
            ResetCameraPosition("BalanceLedge");
            cam.m_Priority = 150;
            if (resetCameraPos == true)
            {
                if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) >= 180 - xAngleMax)
                {
                    //enabling inputs of the camera
                    CamMovement();
                }
                else if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) < 180 - xAngleMax && Vector3.Dot(boyLookAt.right, camTransform.forward) <= 0)
                {
                    //restricting the inputs of the camera when reaching the desired angle
                    if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Joystick X") < 0)
                    {
                        currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
                        currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
                    }
                    currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
                    currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
                    currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
                }
                else if (Vector3.Angle(boyLookAt.forward, cameraProjectionDir) < 180 - xAngleMax && Vector3.Dot(boyLookAt.right, camTransform.forward) >= 0)
                {
                    //restricting the inputs of the camera when reaching the desired angle
                    if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Joystick X") > 0)
                    {
                        currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
                        currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
                    }
                    currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
                    currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
                    currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
                }

            }
        }
        else
        {
            resetCameraPos = false;
            cam.m_Priority = 0;
            

        }
        if (resetCameraPos == true)
        {
            dir.Set(0, 0, -distance);
            camTransform.position = lookAt.position + rotation * dir;
            rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.LookAt(lookAt.position);
        }
    }

    private void CamMovement()
    {
       
        currentX += Input.GetAxis("Mouse X") * InputManager.instance.MouseXSensitivity;
        currentX += Input.GetAxis("Joystick X") * InputManager.instance.JoystickXSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * InputManager.instance.MouseYSensitivity;
        currentY -= Input.GetAxis("Joystick Y") * InputManager.instance.JoystickYSensitivity;
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
       
    }

    private void ResetCameraPosition(string balanceTipe)
    {
        
        if (balanceTipe == "Climbing" && resetCameraPos == false)
        {
            //forcing the input f the camera t reposition it at the back of the character
            currentY = 0;
            currentX = lookAt.eulerAngles.y; 
            resetCameraPos = true;
            //Debug.Log("climb");

        }
        else if (balanceTipe == "BalanceLedge" && resetCameraPos == false) 
        {
            //forcing the input f the camera t reposition it at the front of the character
            currentY = 0; 
            if(boyActive)
            {
                currentX = boyCharacter.balanceCollider.transform.eulerAngles.y - 90;
               // Debug.Log("Balance");
            }
            else if(!boyActive)
            {
                currentX = motherCharacter.balanceCollider.transform.eulerAngles.y - 90;
            }  

            resetCameraPos = true;
        } 

    }  



    public override void SwitchLookAt() 
    {
        if ((int)GMController.instance.isCharacterPlaying == 0)
        {
            boyActive = true;
            StartCoroutine(ResetCameraPriority());
            lookAt = boyLookAtByTag;
        }
        else if ((int)GMController.instance.isCharacterPlaying == 1)
        {
            boyActive = false;
            StartCoroutine(ResetCameraPriority());
            lookAt = motherLookAtByTag;
        }
    }

}