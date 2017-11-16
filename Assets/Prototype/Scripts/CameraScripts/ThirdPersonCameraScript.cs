using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraScript : CameraScript {

        

    // max and min angles of the camera movement
    protected float yAngleMin = -40.0F;
    protected float yAngelMax = 70.0F;



    //Variable for the offset of the raycast that check the collisions of the camera
    private float collisionOffeset = 4.004f;
    //array of the actual position of the clip points
    [HideInInspector]
    public Vector3[] clipPointPositionArray;
    
  
    private void Start()
    {

        SwitchLookAt();
        

        clipPointPositionArray = new Vector3[5];
        camTransform = transform;
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        cam.nearClipPlane = nearClipPlaneDistance;
    }

    private void Update()
    {
        if (Input.GetButton("Submit"))
        {
            SwitchLookAt();
        }

        if (Input.GetButtonDown("Pause"))
        {
            Cursor.lockState = CursorLockMode.None;                     //Riabilita il cursore del mouse premendo ESC

        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;

        }

        // camera movement and limit of movement
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngelMax);

        //camera management of the bound to the player, movement, rotation and look direction
        dir.Set(0, 0, -distance);
        camTransform.position = lookAt.position + rotation * dir;
        rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.LookAt(lookAt.position);

        //collision check controll 
        clipPointsPosition(cam.transform.position, cam.transform.rotation, ref clipPointPositionArray);

        //Debug.DrawRay (lookAt.position, clipPointPositionArray [0] - lookAt.position, Color.red);
        //Debug.DrawRay (lookAt.position, clipPointPositionArray [1] - lookAt.position, Color.green);
        //Debug.DrawRay (lookAt.position, clipPointPositionArray [2] - lookAt.position, Color.blue);
        //Debug.DrawRay (lookAt.position, clipPointPositionArray [3] - lookAt.position);
        Debug.DrawRay(lookAt.position, clipPointPositionArray[4] - lookAt.position);

        float finalDist = 100f;
        for (int i = 0; i < clipPointPositionArray.Length; i++)
        {

            Ray ray = new Ray(lookAt.position, clipPointPositionArray[i] - lookAt.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance, layerIgnored))
            {
                finalDist = Mathf.Min(hit.distance, finalDist);
                distance = finalDist;

            }
            else
            {
                finalDist = Mathf.Min(maxDistance, finalDist);
                distance = finalDist;
            }

        }
    }
    //method used to populate and update the array containing the coordinates of the clipPonts
    public void clipPointsPosition(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] clipArray)
    {
        clipArray = new Vector3[5];

        float z = cam.nearClipPlane;
        float x = Mathf.Tan(cam.fieldOfView / collisionOffeset) * z;
        float y = x / cam.aspect;


        //top left
        clipArray[0] = (atRotation * new Vector3(-x, y, z)) + cameraPosition;
        //top right
        clipArray[1] = (atRotation * new Vector3(x, y, z)) + cameraPosition;
        //bottom left
        clipArray[2] = (atRotation * new Vector3(-x, -y, z)) + cameraPosition;
        //bottom right
        clipArray[3] = (atRotation * new Vector3(x, -y, z)) + cameraPosition;
        //center
        clipArray[4] = cameraPosition - cam.transform.forward;

    }

    public override void SwitchLookAt()
    {
        if ((int)GMController.instance.isCharacterPlaying == 0)
        {
            lookAt = boyLookAtByTag;
        }
        else if ((int)GMController.instance.isCharacterPlaying == 1)
        {
            lookAt = motherLookAtByTag;
        }
    }

}
