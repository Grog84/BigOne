using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFMODOneShot : MonoBehaviour
{

    [SerializeField]
    public FMODEventRef[] m_FMODEventList;

    Dictionary<string, string> eventDict = new Dictionary<string, string>();

    private void Awake()
    {
        
        for (int i = 0; i < m_FMODEventList.Length; i++)
        {
            eventDict.Add(m_FMODEventList[i].audioTag, m_FMODEventList[i].audioEntry);
        }
    }

    public void PlaySound(string key)
    {
        if (eventDict[key] != null)
        {
            FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(eventDict[key]);
            e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

            e.start();
            e.release();
        }
    }
}

