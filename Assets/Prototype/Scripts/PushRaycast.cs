using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRaycast : MonoBehaviour {

    [HideInInspector] public Vector3[] objectRaycastsX;
    [HideInInspector] public Vector3[] objectRaycastsZ;

    private float quarterHight;
    private float quarterWidth;
    private float quarterDepth;

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

        topLineOffset    = +quarterHight;
        bottomLineOffset = -quarterHight;
        verticalColumnOffsetX = +quarterWidth;
        verticalColumnOffsetZ = +quarterDepth;

        // X
        objectRaycastsX = new Vector3[9];
       
        objectRaycastsX[0] = new Vector3(-verticalColumnOffsetX * 2,        bottomLineOffset  , 0);
        objectRaycastsX[1] = new Vector3(0                         ,        bottomLineOffset  , 0);
        objectRaycastsX[2] = new Vector3(+verticalColumnOffsetX * 2,        bottomLineOffset  , 0);

        objectRaycastsX[3] = new Vector3(-verticalColumnOffsetX * 2, 0                        , 0);
        objectRaycastsX[4] = new Vector3(0                         , 0                        , 0);
        objectRaycastsX[5] = new Vector3(+verticalColumnOffsetX * 2, 0                        , 0);

        objectRaycastsX[6] = new Vector3(-verticalColumnOffsetX * 2, topLineOffset * 2, 0);
        objectRaycastsX[7] = new Vector3(0                         , topLineOffset * 2, 0);
        objectRaycastsX[8] = new Vector3(+verticalColumnOffsetX * 2, topLineOffset * 2, 0);

        // Z
        objectRaycastsZ = new Vector3[9];
     
        objectRaycastsZ[0] = new Vector3(0                         , bottomLineOffset , -verticalColumnOffsetZ * 2);
        objectRaycastsZ[1] = new Vector3(0                         , bottomLineOffset ,                          0);
        objectRaycastsZ[2] = new Vector3(0                         , bottomLineOffset , +verticalColumnOffsetZ * 2);

        objectRaycastsZ[3] = new Vector3(0                         , 0                , -verticalColumnOffsetZ * 2);
        objectRaycastsZ[4] = new Vector3(0                         , 0                ,                          0);
        objectRaycastsZ[5] = new Vector3(0                         , 0                , +verticalColumnOffsetZ * 2);

        objectRaycastsZ[6] = new Vector3(0                         , topLineOffset * 2, -verticalColumnOffsetZ * 2);
        objectRaycastsZ[7] = new Vector3(0                         , topLineOffset * 2,                 0);
        objectRaycastsZ[8] = new Vector3(0                         , topLineOffset * 2, +verticalColumnOffsetZ * 2);
    }

   

    private void Update()
    {
        // X
        objectRaycastsX[0] = new Vector3(-verticalColumnOffsetX * 2, bottomLineOffset ,                 0);
        objectRaycastsX[1] = new Vector3(0                         , bottomLineOffset ,                 0);
        objectRaycastsX[2] = new Vector3(+verticalColumnOffsetX * 2, bottomLineOffset ,                 0);

        objectRaycastsX[3] = new Vector3(-verticalColumnOffsetX * 2,                 0,                 0);
        objectRaycastsX[4] = new Vector3(0                         ,                 0,                 0);
        objectRaycastsX[5] = new Vector3(+verticalColumnOffsetX * 2,                 0,                 0);

        objectRaycastsX[6] = new Vector3(-verticalColumnOffsetX * 2,  topLineOffset * 2,                0);
        objectRaycastsX[7] = new Vector3(0                         ,  topLineOffset * 2,                0);
        objectRaycastsX[8] = new Vector3(+verticalColumnOffsetX * 2,  topLineOffset * 2,                0);




        // Z
        objectRaycastsZ[0] = new Vector3(0                ,  bottomLineOffset , -verticalColumnOffsetZ * 2);
        objectRaycastsZ[1] = new Vector3(0                ,  bottomLineOffset ,                          0);
        objectRaycastsZ[2] = new Vector3(0                ,  bottomLineOffset , +verticalColumnOffsetZ * 2);

        objectRaycastsZ[3] = new Vector3(0                ,                  0, -verticalColumnOffsetZ * 2);
        objectRaycastsZ[4] = new Vector3(0                ,                  0,                          0);
        objectRaycastsZ[5] = new Vector3(0                ,                  0, +verticalColumnOffsetZ * 2);

        objectRaycastsZ[6] = new Vector3(0                ,  topLineOffset * 2, -verticalColumnOffsetZ * 2);
        objectRaycastsZ[7] = new Vector3(0                ,  topLineOffset * 2,                          0);
        objectRaycastsZ[8] = new Vector3(0                ,  topLineOffset * 2, +verticalColumnOffsetZ * 2);
    }
}
