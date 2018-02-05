using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRaycast : MonoBehaviour {

    [HideInInspector] public Vector3[] objectRaycastsX;
    [HideInInspector] public Vector3[] objectRaycastsZ;

    [HideInInspector] public float quarterHight;
    [HideInInspector] public float quarterWidth;
    [HideInInspector] public float quarterDepth;

    [HideInInspector] public Vector3 bottomOffset;
    [HideInInspector] public Vector3 topOffset;

    [Range(-1f, 1f)]
    public float bottomLineOffset;
    [Range(-1f, 1f)]
    public float verticalColumnOffsetX;
    [Range(-1f, 1f)]
    public float verticalColumnOffsetZ;
    [Range(-1f, 1f)]
    public float topLineOffset;

    private void Awake()
    {
     
        quarterHight = transform.GetComponent<MeshCollider>().bounds.size.y / 4;
        quarterWidth = transform.GetComponent<MeshCollider>().bounds.size.x / 4;
        quarterDepth = transform.GetComponent<MeshCollider>().bounds.size.z / 4;
       
        // X
        objectRaycastsX = new Vector3[15];
       
        
        // Z
        objectRaycastsZ = new Vector3[15];
     
    }

   

    private void Update()
    {
        bottomOffset = new Vector3(0, bottomLineOffset, 0);
        topOffset = new Vector3(0, topLineOffset * 2, 0);

        #region RayClamp   
        //Clamp Raycast to be inside the Object
        if(bottomLineOffset < -quarterHight * 2)
        {
            bottomLineOffset = -quarterHight * 2;
        }
        else if(bottomLineOffset > 0)
        {
            bottomLineOffset = 0;
        }


        if (verticalColumnOffsetX < 0)
        {
            verticalColumnOffsetX = 0;
        }
        else if (verticalColumnOffsetX > +quarterWidth)
        {
            verticalColumnOffsetX = +quarterWidth;
        }



        if (verticalColumnOffsetZ < 0)
        {
            verticalColumnOffsetZ = 0;
        }
        else if (verticalColumnOffsetZ > +quarterDepth )
        {
            verticalColumnOffsetZ = +quarterDepth ;
        }


        if (topLineOffset < 0)
        {
            topLineOffset = 0;
        }
        else if (topLineOffset > +quarterHight)
        {
            topLineOffset = +quarterHight;
        }
#endregion

        // X
        objectRaycastsX[0] = bottomOffset - transform.right * 2 * verticalColumnOffsetX;
        objectRaycastsX[1] = bottomOffset - transform.right * verticalColumnOffsetX;
        objectRaycastsX[2] = bottomOffset;
        objectRaycastsX[3] = bottomOffset + transform.right * verticalColumnOffsetX;
        objectRaycastsX[4] = bottomOffset + transform.right * 2 * verticalColumnOffsetX;

        objectRaycastsX[5] = - transform.right * 2 * verticalColumnOffsetX;
        objectRaycastsX[6] = - transform.right * verticalColumnOffsetX;
        objectRaycastsX[7] = Vector3.zero;
        objectRaycastsX[8] = transform.right * verticalColumnOffsetX;
        objectRaycastsX[9] = transform.right * 2 * verticalColumnOffsetX;

        objectRaycastsX[10] = topOffset - transform.right * 2 * verticalColumnOffsetX;
        objectRaycastsX[11] = topOffset - transform.right * verticalColumnOffsetX;
        objectRaycastsX[12] = topOffset;
        objectRaycastsX[13] = topOffset + transform.right * verticalColumnOffsetX;
        objectRaycastsX[14] = topOffset + transform.right * 2 * verticalColumnOffsetX;




        // Z
        objectRaycastsZ[0] = bottomOffset - transform.forward * 2 * verticalColumnOffsetZ;
        objectRaycastsZ[1] = bottomOffset - transform.forward  * verticalColumnOffsetZ;
        objectRaycastsZ[2] = bottomOffset;
        objectRaycastsZ[3] = bottomOffset + transform.forward * verticalColumnOffsetZ;
        objectRaycastsZ[4] = bottomOffset + transform.forward * 2 * verticalColumnOffsetZ;

        objectRaycastsZ[5] = -transform.forward * 2 * verticalColumnOffsetZ;
        objectRaycastsZ[6] = -transform.forward * verticalColumnOffsetZ;
        objectRaycastsZ[7] = Vector3.zero;
        objectRaycastsZ[8] = transform.forward * verticalColumnOffsetZ;
        objectRaycastsZ[9] = transform.forward * 2 * verticalColumnOffsetZ;

        objectRaycastsZ[10] = topOffset - transform.forward * 2 * verticalColumnOffsetZ;
        objectRaycastsZ[12] = topOffset - transform.forward * verticalColumnOffsetZ;
        objectRaycastsZ[11] = topOffset;
        objectRaycastsZ[13] = topOffset + transform.forward * verticalColumnOffsetZ;
        objectRaycastsZ[14] = topOffset + transform.forward * 2 * verticalColumnOffsetZ;
    }
}
