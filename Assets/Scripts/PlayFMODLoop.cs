using System.Collections.Generic;
using UnityEngine;
public class PlayFMODLoop : MonoBehaviour
{

    [SerializeField]
    public FMODEventRef[] m_FMODEventList;

    Dictionary<string, FMOD.Studio.EventInstance> eventDict = new Dictionary<string, FMOD.Studio.EventInstance>();

    private void Awake()
    {

        for (int i = 0; i < m_FMODEventList.Length; i++)
        {
            FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(m_FMODEventList[i].audioEntry);
            e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

            eventDict.Add(m_FMODEventList[i].audioTag, e);
        }
    }

    public void StartSound(string key)
    {
        eventDict[key].start();
        
    }

    public void StopSound(string key)
    {
        eventDict[key].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

    }
}

