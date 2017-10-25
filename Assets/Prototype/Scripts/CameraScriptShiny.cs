using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptShiny : MonoBehaviour
{
    public LayerMask layerIgnored = ~(1 << 8);


    // max and min angles of the camera movement
	private const float Y_ANGLE_MIN = -40.0F;
	private const float Y_ANGLE_MAX = 70.0F;


    public Transform motherLookAt;
    public Transform boyLookAt;
    public Transform lookAt;                    // object that the camera is looking at
	private Transform camTransform;
    
	private Camera cam;
    private float camDistance = 0.0f;
    //camera variables for the position 
	private float nearClipPlaneDistance = 0.1f;
    public float distance = 2.5f;
    // position of the camera assigned in the camera movement
    private float currentX = 0.0f;
	private float currentY = 0.0f;
    Vector3 dir = new Vector3();
    Quaternion rotation = new Quaternion();
    //Variable for the offset of the raycast that check the collisions of the camera
    public float collisionOffeset = 4.004f;
	//array of the actual position of the clip points
	[HideInInspector]
	public Vector3[] clipPointPositionArray;



       private void Start()
	{
        lookAt.GetComponentsInParent<Animation>();
		clipPointPositionArray = new Vector3[5];
		camTransform = transform;
		cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        cam.nearClipPlane = nearClipPlaneDistance;
    }

	private void Update ()
	{
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;                     //Riabilita il cursore del mouse premendo ESC
         
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        
        }
        // camera movement and limit of movement
        currentX += Input.GetAxis ("Mouse X");
		currentY -= Input.GetAxis ("Mouse Y");
		currentY = Mathf.Clamp (currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

		//camera management of the bound to the player, movement, rotation and look direction
		dir.Set (0, 0, -distance);
		camTransform.position = lookAt.position + rotation * dir;
		rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.LookAt (lookAt.position);

        //collision check controll 
        clipPointsPosition (cam.transform.position, cam.transform.rotation, ref clipPointPositionArray);

        //Debug.DrawRay (lookAt.position, clipPointPositionArray [0] - lookAt.position, Color.red);
        //Debug.DrawRay (lookAt.position, clipPointPositionArray [1] - lookAt.position, Color.green);
        //Debug.DrawRay (lookAt.position, clipPointPositionArray [2] - lookAt.position, Color.blue);
        //Debug.DrawRay (lookAt.position, clipPointPositionArray [3] - lookAt.position);
        Debug.DrawRay (lookAt.position, clipPointPositionArray [4] - lookAt.position);

        float finalDist = 100f;
		for (int i = 0; i < clipPointPositionArray.Length; i++)
        {
			
			Ray ray = new Ray (lookAt.position, clipPointPositionArray [i] - lookAt.position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 2.5f, layerIgnored))
            {
				finalDist = Mathf.Min(hit.distance, finalDist);
				distance = finalDist;
				
			}
            else 
			{
				finalDist = Mathf.Min(2.5f, finalDist);
				distance = finalDist;
			}

		}
	}
   //method used to populate and update the array containing the coordinates of the clipPonts
	public void clipPointsPosition (Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] clipArray)
	{
		clipArray = new Vector3[5];

		float z = cam.nearClipPlane;
		float x = Mathf.Tan (cam.fieldOfView / collisionOffeset) * z;
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

    public void SwitchLookAt()
    {
        if((int)GMController.instance.isCharacterPlaying == 0)
        {
            lookAt = boyLookAt;
        }
        else if((int)GMController.instance.isCharacterPlaying == 1)
        {
            lookAt = motherLookAt;
        }
    }

}




