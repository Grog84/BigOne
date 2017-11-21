using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Doors : MonoBehaviour
{
    public GameObject rightKey;
    public string doorID;
    public bool isDoorOpen;
    public bool hasKey;

    private OffMeshLink m_offLink;

    void Awake()
    {
        m_offLink = GetComponentInChildren<OffMeshLink>();
        isDoorOpen = false;

        if (gameObject.tag == "LockedDoor")
        {
            doorID = rightKey.GetComponent<Keys>().ItemID;
            hasKey = false;
        }
        else
        {
            hasKey = true;
        }
    }

    public void OpenDoor()
    {
        m_offLink.activated = true;
        isDoorOpen = true;
    }

    public void CloseDoor()
    {
        m_offLink.activated = false;
        isDoorOpen = false;
    }

}
