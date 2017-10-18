using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    [Tooltip("If true the object will be destroyed after activation")]
    public bool isDestroyable = false;

    private void OnTriggerEnter(Collider other)
    {
        GMController.instance.SaveCheckpoint();
        if (isDestroyable)
            Destroy(gameObject);
    }
}
