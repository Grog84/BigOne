using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class CutsceneOnAwake : CutsceneManager
{

    private bool hasStarted = false;

    private void Awake()
    {

        m_PlayableDirector = this.GetComponent<PlayableDirector>();

    }

    private void Update()
    {
        if(GMController.instance.isGameActive && !hasStarted)
        {

            hasStarted = true;
            StartCoroutine(PlayTimeline(m_PlayableDirector));
           
        }
    }

}
