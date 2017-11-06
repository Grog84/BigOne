using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Doors : MonoBehaviour
{
    public GameObject rightKey;
    public string doorID;
    public bool isDoorOpen;

    private OffMeshLink m_offLink;

    void Start()
    {
        m_offLink = GetComponentInChildren<OffMeshLink>();

        if (gameObject.tag == "LockedDoor")
        {
            doorID = rightKey.GetComponent<Keys>().keyID;
        }

        isDoorOpen = false;
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
