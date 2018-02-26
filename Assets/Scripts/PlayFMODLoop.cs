using System.Collections.Generic;
using UnityEngine;

public class PlayFMODLoop : MonoBehaviour
{

    [SerializeField]
    public FMODEventRef[] m_FMODEventList;

    List<string> activeSoundsKeys = new List<string>();

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
        activeSoundsKeys.Add(key);
    }

    public void StopSound(string key)
    {
        eventDict[key].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        activeSoundsKeys.Remove(key);
    }

    private void Update()
    {
        if (activeSoundsKeys.Count != 0)
        {
            foreach (var key in activeSoundsKeys)
            {
                FMOD.VECTOR sourcePos = new FMOD.VECTOR() {
                    x = transform.position.x ,
                    y = transform.position.y ,
                    z = transform.position.z };

                FMOD.ATTRIBUTES_3D m_Attribute = new FMOD.ATTRIBUTES_3D();
                m_Attribute.position = sourcePos;

                eventDict[key].set3DAttributes(m_Attribute);
            }
            
        }

    }
}


