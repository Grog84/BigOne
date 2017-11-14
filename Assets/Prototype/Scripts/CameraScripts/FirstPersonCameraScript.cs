using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonCameraScript : MonoBehaviour {

    // max and min angles of the camera movement
    private const float Y_ANGLE_MIN = -40.0F;
    private const float Y_ANGLE_MAX = 70.0F;

    CinemachineVirtualCamera myCamera;
    private Transform motherLookAtByTag;
    private Transform boyLookAtByTag;
    public Transform motherLookAt;
    public Transform boyLookAt;

    // position of the camera assigned in the camera movement
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    Quaternion rotation = new Quaternion();

    private void Awake()
    {
        motherLookAtByTag = motherLookAt.FindDeepChildByTag("LookAtCamera");
        boyLookAtByTag = boyLookAt.FindDeepChildByTag("LookAtCamera");
    }

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
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        rotation = Quaternion.Euler (currentY, currentX, 0);
        transform.rotation = rotation;

    }

    public void SwitchLookAt()
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
