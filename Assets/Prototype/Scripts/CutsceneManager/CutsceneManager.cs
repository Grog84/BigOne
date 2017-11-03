using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
   
    
    public PlayableDirector m_PlayableDirector;
    protected bool trigger = false;
    public bool characterControlEnabled = false;


   


    public IEnumerator PlayTimeline(PlayableDirector playableDirector, bool triggered ,bool characterControllable)
    {
        if (triggered == false)
        {
            playableDirector.Play();
        }
        trigger = true;

        if(characterControllable == false)
        {
            if(playableDirector.playableGraph.IsPlaying())
            {
                //Debug.Log("INIZIATO");
                GMController.instance.SetActive(false);
            }

            yield return new WaitForSeconds((float)playableDirector.duration);

            if(playableDirector.state != PlayState.Playing)
            {
                GMController.instance.SetActive(true);
            }
        }



        yield return null;
    }
	
    
        
   

}
