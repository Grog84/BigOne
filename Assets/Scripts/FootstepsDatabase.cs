using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace CustomAudio
{
    [CreateAssetMenu(menuName = "Audio/FootstepsDatabase")]
    [Serializable]
    public class FootstepsDatabase : ScriptableObject {

        public AudioEntry[] entryList;

        AudioEntry GetEntry(TerrainTexture texture)
        {
            foreach (AudioEntry entry in entryList)
            {
                if (entry.m_Texture == texture)
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
        public TerrainTexture m_Texture;
        [ReadOnly]
        public string FMOD_Parameter = "";
        public int value;
    }
}
