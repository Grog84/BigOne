using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneInteractable : CutsceneManager
{
    private Icons icons;

    private void Start()
    {
        icons = GameObject.FindObjectOfType<Icons>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            icons.transform.Find("Cinematic").gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            icons.transform.Find("Cinematic").gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButtonDown("Interact") && !trigger)
        {
            StartCoroutine(PlayTimeline(m_PlayableDirector));
        }
    }

}
