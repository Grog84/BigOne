using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Icons : MonoBehaviour
{
    public CharacterStateController controllerMother;
    public CharacterStateController controllerBoy;

    void Awake ()
    {
        controllerMother = GameObject.Find("Mother").GetComponent<CharacterStateController>();
        controllerBoy = GameObject.Find("Boy").GetComponent<CharacterStateController>();
    }
	

	void Update ()
    {
        // Climb Icon
		if(controllerBoy.thisCharacter == CharacterActive.Boy && controllerBoy.m_CharacterController.isClimbDirectionRight)
        {
            gameObject.transform.Find("Climb").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.Find("Climb").gameObject.SetActive(false);
        }

        // Push Icon
        if (controllerMother.thisCharacter == CharacterActive.Mother && controllerMother.m_CharacterController.isPushDirectionRight)
        {
            gameObject.transform.Find("Push").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.Find("Push").gameObject.SetActive(false);
        }

        // Door Icon
        if ( controllerMother.m_CharacterController.isDoorDirectionRight || controllerBoy.m_CharacterController.isDoorDirectionRight)
        {
            gameObject.transform.Find("Door").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.Find("Door").gameObject.SetActive(false);
        }
        // Collect Icon
        if (controllerMother.m_CharacterController.isInKeyArea || controllerBoy.m_CharacterController.isInKeyArea)
        {
            gameObject.transform.Find("Key").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.Find("Key").gameObject.SetActive(false);
        }

    }
}
