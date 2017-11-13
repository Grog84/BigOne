using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraCollisionDetection : MonoBehaviour
{
    CinemachineOrbitalTransposer orbit;
    CinemachineFreeLook myCamera;
    public LayerMask layerIgnored = ~(1 << 8);
    //Variable for the offset of the raycast that check the collisions of the camera
    public float collisionOffeset = 4.004f;
    //array of the actual position of the clip points
    [HideInInspector]
    public Vector3[] clipPointPositionArray;


    public float distance = 2.5f;
    public float maxDistance = 2.5f;
    private Camera cam;
    Transform myLookAt;

    private void Start()
    {
        myCamera = GetComponent<CinemachineFreeLook>();
        orbit = myCamera.GetComponent<CinemachineOrbitalTransposer>();
        Debug.Log(orbit);
        clipPointPositionArray = new Vector3[5];
        cam = Camera.main;
        myLookAt = myCamera.LookAt;

    }

    private void Update()
    {
        myLookAt = myCamera.LookAt;
        

        clipPointsPosition(cam.transform.position, cam.transform.rotation, ref clipPointPositionArray);

        Debug.DrawRay(myLookAt.position, clipPointPositionArray[0] - myLookAt.position, Color.red);
        Debug.DrawRay (myLookAt.position, clipPointPositionArray [1] - myLookAt.position, Color.green);
        Debug.DrawRay (myLookAt.position, clipPointPositionArray [2] - myLookAt.position, Color.blue);
        Debug.DrawRay (myLookAt.position, clipPointPositionArray [3] - myLookAt.position);

        float finalDist = 100f;
        for (int i = 0; i < clipPointPositionArray.Length; i++)
        {

            Ray ray = new Ray(myLookAt.position, clipPointPositionArray[i] - myLookAt.position);
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
        //toprig
        myCamera.DefaultRadius[0] = distance / 2;
        //middleRig
        myCamera.DefaultRadius[1] = distance;
        //bottomRig
        myCamera.DefaultRadius[2] = distance / 2;



    }

    public void clipPointsPosition(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] clipArray)
    {
        Debug.Log("esisto");
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


}
