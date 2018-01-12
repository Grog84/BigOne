using UnityEngine;
using Cinemachine;
public class CameraCollision : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    private CameraScript mainCam;
    private CameraScript myCameraScript;
    //Variable for the offset of the raycast that check the collisions of the camera
    public float collisionOffesetX = 4.004f;
    public float collisionOffsetY = 0f;
    public float collisionOffsetZ = 0f;
    //array of the actual position of the clip points
    [HideInInspector]
    public Vector3[] clipPointPositionArray;
    [SerializeField]
    public LayerMask layerIgnored = ~(1 << 8);

    private void Start()
    {
        cam = this.GetComponent<CinemachineVirtualCamera>();
        myCameraScript = this.GetComponent<CameraScript>();
        clipPointPositionArray = new Vector3[5];
    } 

    private void Update()
    {
        //collision check controll 
        clipPointsPosition(cam.transform.position, cam.transform.rotation, ref clipPointPositionArray);


        //Series of Debug controlls 
        //Debug.DrawRay(myCameraScript.lookAt.position, clipPointPositionArray[0] - myCameraScript.lookAt.position, Color.red);
        //Debug.DrawRay(myCameraScript.lookAt.position, clipPointPositionArray[1] - myCameraScript.lookAt.position, Color.green);
        //Debug.DrawRay(myCameraScript.lookAt.position, clipPointPositionArray[2] - myCameraScript.lookAt.position, Color.blue);
        //Debug.DrawRay(myCameraScript.lookAt.position, clipPointPositionArray[3] - myCameraScript.lookAt.position);
        //Debug.DrawRay(myCameraScript.lookAt.position, clipPointPositionArray[4] - myCameraScript.lookAt.position);


        // Camera repositioning on collision
        float finalDist = 100f;
        for (int i = 0; i < clipPointPositionArray.Length; i++)
        {
            Ray ray = new Ray(myCameraScript.lookAt.position, clipPointPositionArray[i] - myCameraScript.lookAt.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, myCameraScript.maxDistance, layerIgnored))
            {
                finalDist = Mathf.Min(hit.distance, finalDist);
                myCameraScript.distance = finalDist;
            }
            else
            {
                finalDist = Mathf.Min(myCameraScript.maxDistance, finalDist);
                myCameraScript.distance = finalDist;
            }
        }

    }

    public void clipPointsPosition(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] clipArray)
    {
        clipArray = new Vector3[5];

        float z = Camera.main.nearClipPlane;
        float x = Mathf.Tan(cam.m_Lens.FieldOfView / collisionOffesetX) * z;
        float y = (x / cam.m_Lens.Aspect)+collisionOffsetY;


        //top left
        clipArray[0] = (atRotation * new Vector3(-x, y, (z+collisionOffsetZ))) + cameraPosition;
        //top right
        clipArray[1] = (atRotation * new Vector3(x, y, (z + collisionOffsetZ))) + cameraPosition;
        //bottom left
        clipArray[2] = (atRotation * new Vector3(-x, -y, (z + collisionOffsetZ))) + cameraPosition;
        //bottom right
        clipArray[3] = (atRotation * new Vector3(x, -y, (z + collisionOffsetZ))) + cameraPosition;
        //center
        clipArray[4] = cameraPosition - cam.transform.forward;

    }

}


