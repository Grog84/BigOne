using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class NavPointCreator : MonoBehaviour
{
    public Guard m_Guard;

    public void AddNavpoint(NavPoint nvPoint)
    {
        m_Guard.wayPointList.Add(nvPoint);
    }
	
}
