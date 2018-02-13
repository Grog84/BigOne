using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFMODOneShot : MonoBehaviour {

    [FMODUnity.EventRef]
    public string m_ClimbPath;

    [FMODUnity.EventRef]
    public string m_ClimbPath2;

    string[] allSounds;

    private void Awake()
    {
        allSounds = new string[2];
        allSounds[0] = m_ClimbPath;
        allSounds[1] = m_ClimbPath2;
    }

    public void PlaySound(int soundIdx)
    {
        if (allSounds[soundIdx] != null)
        {
            FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(allSounds[soundIdx]);
            e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

            e.start();
            e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
        }
    }
}
