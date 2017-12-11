using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using StateMachine;

public class CharacterSwitch : MonoBehaviour
{
    CharacterActive character = CharacterActive.None;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            character = other.GetComponent<CharacterStateController>().thisCharacter;
            GMController.instance.canSwitch = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && GMController.instance.isCharacterPlaying == character)
        {
            character = other.GetComponent<CharacterStateController>().thisCharacter;
            GMController.instance.canSwitch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            character = CharacterActive.None;
            GMController.instance.canSwitch = false;
        }
    }

    
}
