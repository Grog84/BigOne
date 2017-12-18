using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    // Needed for Singleton pattern 
    [HideInInspector] public static InputManager instance = null;

    // Camera sensitivity
    public float MouseXSensitivity = 1f;
    public float MouseYSensitivity = 1f;
    public float JoystickXSensitivity = 1f;
    public float JoystickYSensitivity = 1f;


    private void Start()
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
