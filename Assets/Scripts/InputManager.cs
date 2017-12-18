using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputManager : MonoBehaviour {

    // Needed for Singleton pattern 
    [HideInInspector] public static InputManager instance = null;

    // Camera sensitivity
    public float MouseXSensitivity = 1f;
    public float MouseYSensitivity = 1f;
    public float JoystickXSensitivity = 1f;
    public float JoystickYSensitivity = 1f;

    public enum inputState
    {
        MouseKeyboard,
        Controller
    };
    private inputState m_State = inputState.MouseKeyboard;

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

    private void OnGUI()
    {
        switch (m_State)
        {
            case inputState.MouseKeyboard:
                if (isControlerInput())
                {
                    m_State = inputState.Controller;
                    Debug.Log("JoyStick being used");
                }
                break;
            case inputState.Controller:
                if (isMouseKeyboard())
                {
                    m_State = inputState.MouseKeyboard;
                    Debug.Log("Mouse & Keyboard being used");
                }
                break;
        }
    }

    public inputState GetInputState()
    {
        return m_State;
    }

    private bool isMouseKeyboard()
    {
        // mouse & keyboard buttons
        if (Event.current.isKey ||
            Event.current.isMouse)
        {
            return true;
        }
        // mouse movement
        if (Input.GetAxis("Mouse X") != 0.0f ||
            Input.GetAxis("Mouse Y") != 0.0f)
        {
            return true;
        }
        return false;
    }

    private bool isControlerInput()
    {
        // joystick buttons
        if (Input.GetKey(KeyCode.JoystickButton0) ||
           Input.GetKey(KeyCode.JoystickButton1) ||
           Input.GetKey(KeyCode.JoystickButton2) ||
           Input.GetKey(KeyCode.JoystickButton3) ||
           Input.GetKey(KeyCode.JoystickButton4) ||
           Input.GetKey(KeyCode.JoystickButton5) ||
           Input.GetKey(KeyCode.JoystickButton6) ||
           Input.GetKey(KeyCode.JoystickButton7) ||
           Input.GetKey(KeyCode.JoystickButton8) ||
           Input.GetKey(KeyCode.JoystickButton9) ||
           Input.GetKey(KeyCode.JoystickButton10) ||
           Input.GetKey(KeyCode.JoystickButton11) ||
           Input.GetKey(KeyCode.JoystickButton12) ||
           Input.GetKey(KeyCode.JoystickButton13) ||
           Input.GetKey(KeyCode.JoystickButton14) ||
           Input.GetKey(KeyCode.JoystickButton15) ||
           Input.GetKey(KeyCode.JoystickButton16) ||
           Input.GetKey(KeyCode.JoystickButton17) ||
           Input.GetKey(KeyCode.JoystickButton18) ||
           Input.GetKey(KeyCode.JoystickButton19))
        {
            return true;
        }

        // joystick axis
        if (Input.GetAxis("Joystick X") != 0.0f ||
           Input.GetAxis("Joystick Y") != 0.0f)
        {
            return true;
        }

        return false;
    }

}
