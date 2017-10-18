using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadChkPt : MonoBehaviour {

    public float rotSpeed = 1f;

    private void OnTriggerEnter(Collider other)
    {
        GMController.instance.LoadCheckpoint();
    }

    private void Update()
    {
        transform.Rotate(0f, rotSpeed, 0f);
    }
}
