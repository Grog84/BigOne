using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class SetInjuredStateAtStart : MonoBehaviour
{
    _CharacterController player;
    void Awake ()
    {
        player = GameObject.Find("Mother").GetComponent<_CharacterController>();
        player.isInjured = true;
    }
	
}
