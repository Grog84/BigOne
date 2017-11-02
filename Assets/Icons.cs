using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Icons : MonoBehaviour
{
    [HideInInspector] public CharacterStateController controllerMother;
    [HideInInspector] public CharacterStateController controllerBoy;

    void Awake ()
    {
        controllerMother = GameObject.Find("Mother").GetComponent<CharacterStateController>();
        controllerBoy = GameObject.Find("Boy").GetComponent<CharacterStateController>();
    }
	

	void Update ()
    {
        // If Boy Is Active
        if (GMController.instance.isCharacterPlaying == controllerBoy.thisCharacter)
        {
            // Set Push Icon False
            gameObject.transform.Find("Push").gameObject.SetActive(false);
            
            // Climb Icon
            if (controllerBoy.thisCharacter == CharacterActive.Boy && controllerBoy.m_CharacterController.isClimbDirectionRight)
            {
                gameObject.transform.Find("Climb").gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.Find("Climb").gameObject.SetActive(false);
            }

            // Door Icon 
            if (controllerBoy.m_CharacterController.isDoorDirectionRight && !controllerBoy.m_CharacterController.isClimbDirectionRight)
            {
                gameObject.transform.Find("Door").gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.Find("Door").gameObject.SetActive(false);
            }
            // Collect Icon
            if (controllerBoy.m_CharacterController.isInKeyArea && !controllerBoy.m_CharacterController.isClimbDirectionRight)
            {
                gameObject.transform.Find("Key").gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.Find("Key").gameObject.SetActive(false);
            }
        }
        // If Mother Is Active
        else if (GMController.instance.isCharacterPlaying == controllerMother.thisCharacter)
        {
            // Set Climb Icon False
            gameObject.transform.Find("Climb").gameObject.SetActive(false);

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
            if ( controllerMother.m_CharacterController.isDoorDirectionRight && !controllerMother.m_CharacterController.isPushDirectionRight)
            {
                gameObject.transform.Find("Door").gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.Find("Door").gameObject.SetActive(false);
            }
           
            // Collect Icon
            if (controllerMother.m_CharacterController.isInKeyArea && !controllerMother.m_CharacterController.isPushDirectionRight)
            {
                gameObject.transform.Find("Key").gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.Find("Key").gameObject.SetActive(false);
            }
        }
        

    }
}
