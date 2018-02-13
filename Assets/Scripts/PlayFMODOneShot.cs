using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFMODOneShot : MonoBehaviour
{

    [FMODUnity.MultipleFMOD]
    public string m_ClimbPath;

    [FMODUnity.EventRef]
    public string m_PickItem;

    [FMODUnity.EventRef]
    public string m_OpenDoor;

    [FMODUnity.EventRef]
    public string m_LockedDoor;

    string[] allSounds;

    private void Awake()
    {
        allSounds = new string[6];
        allSounds[0] = m_ClimbPath;
        allSounds[1] = m_PickItem;
        allSounds[2] = m_OpenDoor;
        allSounds[3] = m_LockedDoor;
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

