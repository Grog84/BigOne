using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCheck : MonoBehaviour {


	public GameObject keyboardIcon;
	public GameObject joystickIcon;


	void Start () 
	{
		
	}
	

	void Update () 
	{
		if(InputManager.instance.GetInputState() == InputManager.InputState.MouseKeyboard)
		{
			keyboardIcon.SetActive () = true;
			joystickIcon.SetActive () = false;
		}
		if(InputManager.instance.GetInputState() == InputManager.InputState.Controller)
		{
			keyboardIcon.SetActive () = false;
			joystickIcon.SetActive () = true;
		}
	}
}
