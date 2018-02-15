using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StateMachine;
using DG.Tweening;



public class PauseCamera : CameraScript
{

    // max and min angles of the camera movement
    protected float yAngleMin = -40.0F;
    protected float yAngleMax = 70.0F;
    protected CinemachineVirtualCamera cam;
    private CameraScript mainCam;
    protected CharacterStateController controllerBoy;
    bool triggeredMethod = false;
    bool paused = false;

    protected void Start()
    {
        mainCam = Camera.main.GetComponent<CameraScript>();
        this.minCamDistance = mainCam.minCamDistance;
        this.maxDistance = mainCam.maxDistance;

        SwitchLookAt();
        camTransform = transform;
        cam = this.GetComponent<CinemachineVirtualCamera>();
        //Cursor.lockState = CursorLockMode.Locked;
        cam.m_Lens.NearClipPlane = nearClipPlaneDistance;

    }

    private void Update()
    {
        //if (Input.GetButtonDown("Pause") && !paused)
        //{
        //    paused = true;
        //    transform.position = PositionOnActiveCamera().transform.position;
        //    transform.forward = PositionOnActiveCamera().transform.forward;

        //    cam.m_Priority = 1000;
        //}
        //else if (Input.GetButtonDown("Pause") && paused)
        //{
        //    Resume();
        //}
    }

    private CinemachineVirtualCamera PositionOnActiveCamera()
    {
        int highestPriority = 0;
        if (!triggeredMethod)
        {
            for (int i = 0; i < camerasInScene.Length; i++)
            {
                if (camerasInScene[i].m_Priority > highestPriority)
                {
                    highestPriority = camerasInScene[i].m_Priority;

                }

            }

            for (int i = 0; i < camerasInScene.Length; i++)
            {
                if (camerasInScene[i].m_Priority == highestPriority)
                {
                    //transform.position = camerasInScene[i].transform.position;
                    //transform.forward = camerasInScene[i].transform.forward;
                    return camerasInScene[i];
                }

            }
            triggeredMethod = true;
        }
        return null;
    }

    public void Resume()
    {
        if (paused)
        {
            paused = false;
            cam.m_Priority = 0;
            triggeredMethod = false;
        }
        else
        {
            paused = true;
            transform.position = PositionOnActiveCamera().transform.position;
            transform.forward = PositionOnActiveCamera().transform.forward;

            cam.m_Priority = 1000;
        }
        //    yield return null;
    }



    public override void SwitchLookAt()
    {
        // Debug.Log("SwitchPaused");

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


