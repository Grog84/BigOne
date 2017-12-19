using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomAudio
{
    [CreateAssetMenu(menuName = "Audio/AudioDatabase")]
    [Serializable]
    public class AudioDatabase : ScriptableObject {

        public AudioEntry[] entryList;

        AudioEntry GetEntry(Material material)
        {
            foreach (AudioEntry entry in entryList)
            {
                if (entry.m_Material == material)
                {
                    return entry;
                }
            }

            return null;
        }
    }

    [Serializable]
    public class AudioEntry
    {
        public Material m_Material;
        public FloorDescription m_Description;
    }
}
