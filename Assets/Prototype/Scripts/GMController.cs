using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMController : MonoBehaviour {

    public static GMController instance = null;

    public Vector3 playerPosition;
    public Vector3 lastSeenPlayerPosition;

    void Awake() 
    {
        //Singleton
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);
    }



}
