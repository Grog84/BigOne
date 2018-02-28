using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using StateMachine;

public class CharacterSwitch : MonoBehaviour
{
    CharacterActive character = CharacterActive.None;
    [HideInInspector] public GameObject activePlayer;
    public List<GameObject> players;

    private void Awake()
    {
        players = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            players.Add(other.gameObject);
            character = other.GetComponent<CharacterStateController>().thisCharacter;
            GMController.instance.canSwitch = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (players.Count > 1)
            {
                if (GMController.instance.isCharacterPlaying == players[0].GetComponent<CharacterStateController>().thisCharacter || (GMController.instance.isCharacterPlaying == players[1].GetComponent<CharacterStateController>().thisCharacter))
                {
                    activePlayer = other.gameObject;
                    character = other.GetComponent<CharacterStateController>().thisCharacter;
                    transform.parent.GetComponent<CharacterSwitchIconsActivation>().ShowIcon(activePlayer);
                    GMController.instance.canSwitch = true;
                }

            }
            else if (GMController.instance.isCharacterPlaying == players[0].GetComponent<CharacterStateController>().thisCharacter)
            {
                activePlayer = other.gameObject;
                character = other.GetComponent<CharacterStateController>().thisCharacter;
                transform.parent.GetComponent<CharacterSwitchIconsActivation>().ShowIcon(activePlayer);
                GMController.instance.canSwitch = true;
            }
            else if (GMController.instance.isCharacterPlaying != players[0].GetComponent<CharacterStateController>().thisCharacter)
            {
                transform.parent.GetComponent<CharacterSwitchIconsActivation>().HideIcons();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            players.Remove(other.gameObject);
            //transform.parent.GetComponent<CharacterSwitchIconsActivation>().HideIcons();
            character = CharacterActive.None;
            GMController.instance.canSwitch = false;
        }
    }

    
}
