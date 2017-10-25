using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject rightKey;
    public string doorID;
    public bool isDoorOpen;

    void Start()
    {
        if (gameObject.tag == "LockedDoor")
        {
            doorID = rightKey.GetComponent<Keys>().keyID;
        }

        isDoorOpen = false;
    }

}
