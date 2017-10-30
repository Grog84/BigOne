using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.Timeline;


public class CutsceneOnAwake : CutsceneManager
{

    private void Awake()
    {
        m_PlayableDirector = this.GetComponent<PlayableDirector>();

        StartCoroutine(PlayTimeline(m_PlayableDirector, trigger, characterControlEnabled));
    }

}
