using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRaycast : MonoBehaviour {

    [HideInInspector] public Vector3[] objectRaycastsX;
    [HideInInspector] public Vector3[] objectRaycastsZ;

    [HideInInspector] public float quarterHight;
    [HideInInspector] public float quarterWidth;
    [HideInInspector] public float quarterDepth;

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


        // X
        objectRaycastsX[0] = new Vector3(-verticalColumnOffsetX * 2, bottomLineOffset ,                 0);
        objectRaycastsX[1] = new Vector3(-verticalColumnOffsetX    , bottomLineOffset ,                 0);
        objectRaycastsX[2] = new Vector3(0                         , bottomLineOffset ,                 0);
        objectRaycastsX[3] = new Vector3(+verticalColumnOffsetX    , bottomLineOffset ,                 0);
        objectRaycastsX[4] = new Vector3(+verticalColumnOffsetX * 2, bottomLineOffset ,                 0);

        objectRaycastsX[5] = new Vector3(-verticalColumnOffsetX * 2,                 0,                 0);
        objectRaycastsX[6] = new Vector3(-verticalColumnOffsetX    ,                 0,                 0);
        objectRaycastsX[7] = new Vector3(0                         ,                 0,                 0);
        objectRaycastsX[8] = new Vector3(+verticalColumnOffsetX    ,                 0,                 0);
        objectRaycastsX[9] = new Vector3(+verticalColumnOffsetX * 2,                 0,                 0);

        objectRaycastsX[10] = new Vector3(-verticalColumnOffsetX * 2,  topLineOffset * 2,                0);
        objectRaycastsX[11] = new Vector3(-verticalColumnOffsetX    ,  topLineOffset * 2,                0);
        objectRaycastsX[12] = new Vector3(0                         ,  topLineOffset * 2,                0);
        objectRaycastsX[13] = new Vector3(+verticalColumnOffsetX    ,  topLineOffset * 2,                0);
        objectRaycastsX[14] = new Vector3(+verticalColumnOffsetX * 2,  topLineOffset * 2,                0);




        // Z
        objectRaycastsZ[0] = new Vector3(0                ,  bottomLineOffset , -verticalColumnOffsetZ * 2);
        objectRaycastsZ[1] = new Vector3(0                ,  bottomLineOffset , -verticalColumnOffsetZ    );
        objectRaycastsZ[2] = new Vector3(0                ,  bottomLineOffset ,                          0);
        objectRaycastsZ[3] = new Vector3(0                ,  bottomLineOffset , +verticalColumnOffsetZ    );
        objectRaycastsZ[4] = new Vector3(0                ,  bottomLineOffset , +verticalColumnOffsetZ * 2);

        objectRaycastsZ[5] = new Vector3(0                ,                  0, -verticalColumnOffsetZ * 2);
        objectRaycastsZ[6] = new Vector3(0                ,                  0, -verticalColumnOffsetZ    );
        objectRaycastsZ[7] = new Vector3(0                ,                  0,                          0);
        objectRaycastsZ[8] = new Vector3(0                ,                  0, +verticalColumnOffsetZ    );
        objectRaycastsZ[9] = new Vector3(0                ,                  0, +verticalColumnOffsetZ * 2);

        objectRaycastsZ[10] = new Vector3(0                ,  topLineOffset * 2, -verticalColumnOffsetZ * 2);
        objectRaycastsZ[12] = new Vector3(0                ,  topLineOffset * 2, -verticalColumnOffsetZ    );
        objectRaycastsZ[11] = new Vector3(0                ,  topLineOffset * 2,                          0);
        objectRaycastsZ[13] = new Vector3(0                ,  topLineOffset * 2, -verticalColumnOffsetZ    );
        objectRaycastsZ[14] = new Vector3(0                ,  topLineOffset * 2, +verticalColumnOffsetZ * 2);
    }
}
