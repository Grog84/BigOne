using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace MissionManagerStuff
{
    public class QuestObject:SerializedMonoBehaviour
    {
        [HideInInspector]
        public string name;
        [HideInInspector]
        public bool Picked = false;
        [HideInInspector]
        public bool Bringed = false;

    }
}

