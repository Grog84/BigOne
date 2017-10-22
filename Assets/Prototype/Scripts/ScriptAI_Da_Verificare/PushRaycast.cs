using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRaycast : MonoBehaviour {

    [HideInInspector] public Vector3[] objectRaycastsX;
    [HideInInspector] public Vector3[] objectRaycastsZ
        ;
    private float quarterHight;
    private float quarterWidth;
    private float quarterDepth;

    private void Awake()
    {
        objectRaycastsX = new Vector3[9];

        quarterHight = transform.parent.GetComponent<Collider>().bounds.size.y / 4;
        quarterWidth = transform.parent.GetComponent<Collider>().bounds.size.x / 4;
        quarterDepth = transform.parent.GetComponent<Collider>().bounds.size.z / 4;

        objectRaycastsX[0] = new Vector3(-quarterWidth*2, -quarterHight  , 0);
        objectRaycastsX[1] = new Vector3(0              , -quarterHight  , 0);
        objectRaycastsX[2] = new Vector3(+quarterWidth*2, -quarterHight  , 0);

        objectRaycastsX[3] = new Vector3(-quarterWidth*2, 0              , 0);
        objectRaycastsX[4] = new Vector3(0              , 0              , 0);
        objectRaycastsX[5] = new Vector3(+quarterWidth*2, 0              , 0);

        objectRaycastsX[6] = new Vector3(-quarterWidth*2, +quarterHight*2, 0);
        objectRaycastsX[7] = new Vector3(0              , +quarterHight*2, 0);
        objectRaycastsX[8] = new Vector3(+quarterWidth*2, +quarterHight*2, 0);

        objectRaycastsZ = new Vector3[9];

        objectRaycastsZ[0] = new Vector3(0, -quarterHight    , -quarterDepth * 2);
        objectRaycastsZ[1] = new Vector3(0, -quarterHight    ,                 0);
        objectRaycastsZ[2] = new Vector3(0, -quarterHight    , +quarterDepth * 2);

        objectRaycastsZ[3] = new Vector3(0, 0                , -quarterDepth * 2);
        objectRaycastsZ[4] = new Vector3(0, 0                ,                 0);
        objectRaycastsZ[5] = new Vector3(0, 0                , +quarterWidth * 2);

        objectRaycastsZ[6] = new Vector3(0, +quarterHight * 2, -quarterDepth * 2);
        objectRaycastsZ[7] = new Vector3(0, +quarterHight * 2,                 0);
        objectRaycastsZ[8] = new Vector3(0, +quarterHight * 2, +quarterDepth * 2);
    }

}
