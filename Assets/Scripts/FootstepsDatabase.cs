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

        [TableList]
        public List<FootstepsEntryDB> entryList = new List<FootstepsEntryDB>();
    }

    [Serializable]
    public class FootstepsEntryDB
    {
        public TerrainTexture texture;
        public int FMODValue;
    }

}
