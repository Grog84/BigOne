using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    protected LayerMask layerIgnored = ~(1 << 8);

    //variables initialized at start 
    protected Transform motherLookAt;
    protected Transform boyLookAt;
    protected Transform motherLookAtByTag;
    protected Transform boyLookAtByTag;
    protected Transform lookAt;                    // object that the camera is looking at
    protected Transform camTransform;

    protected Camera cam;
    protected float camDistance = 0.0f;
    //camera variables for the position 
    protected float nearClipPlaneDistance = 0.1f;
    protected float distance = 2.5f;
    public float maxDistance = 2.5f;
    // position of the camera assigned in the camera movement
    protected float currentX = 0.0f;
    protected float currentY = 0.0f;
    protected Vector3 dir = new Vector3();
    protected Quaternion rotation = new Quaternion();


    public virtual void SwitchLookAt(){}

    protected void Awake()
    {
        motherLookAt = GameObject.Find("Mother").GetComponent<Transform>();       
        boyLookAt = GameObject.Find("Boy").GetComponent<Transform>();

        motherLookAtByTag = motherLookAt.FindDeepChildByTag("LookAtCamera");
        boyLookAtByTag = boyLookAt.FindDeepChildByTag("LookAtCamera");
    }


}
    




