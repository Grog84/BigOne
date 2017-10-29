using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    
    public PlayableDirector m_PlayableDirector;
    public bool trigger = false;
    public bool characterControlEnabled = false;

    public void PlayTimeline(PlayableDirector playableDirector, bool triggered)
    {
        if (triggered == false)
        {
            playableDirector.Play();
        }

        trigger = true;
    }
	
}
