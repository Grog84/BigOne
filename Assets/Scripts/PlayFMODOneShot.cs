using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFMODOneShot : MonoBehaviour
{

    [SerializeField]
    public FMODEventRef[] m_FMODEventList;

    string[] allSounds;

    private void Awake()
    {
        allSounds = new string[m_FMODEventList.Length];
        for (int i = 0; i < m_FMODEventList.Length; i++)
        {
            allSounds[i] = m_FMODEventList[i].audioEntry;
        }
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

//public class PlayFMODLoop : MonoBehaviour
//{

//    [FMODUnity.EventRef]
//    public string m_ClimbPath;


//    string[] allSounds;

//    private void Awake()
//    {
//        allSounds = new string[6];
//        allSounds[0] = m_ClimbPath;
//        allSounds[1] = m_PickItem;
//        allSounds[2] = m_OpenDoor;
//        allSounds[3] = m_LockedDoor;
//    }

//    public void PlaySound(int soundIdx)
//    {
//        if (allSounds[soundIdx] != null)
//        {
//            FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(allSounds[soundIdx]);
//            e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

//            e.start();
//            e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
//        }
//    }
//}

