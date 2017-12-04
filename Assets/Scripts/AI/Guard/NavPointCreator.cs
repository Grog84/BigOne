using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class NavPointCreator : MonoBehaviour
{
    public Guard m_Guard;
    public GameObject navPoint;

    //Gizmos
    float sphereMovementTotalTime = 10f;
    float sphereMovementTime = 0f;

    public void AddNavpoint(NavPoint nvPoint)
    {
        m_Guard.wayPointList.Add(nvPoint);
    }

}
