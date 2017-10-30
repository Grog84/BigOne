using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneInteractable : CutsceneManager
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButtonDown("Interact") && !trigger)
        {
            StartCoroutine(PlayTimeline(m_PlayableDirector, trigger, characterControlEnabled));
        }
    }

}
