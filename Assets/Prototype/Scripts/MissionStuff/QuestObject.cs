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
        public Mission m_Mission;
        [HideInInspector]
        public string m_Name;

        //[HideInInspector]
        //public bool Picked = false;
        //[HideInInspector]
        //public bool Bringed = false;

        public void CompleteQuest()
        {
            m_Mission.completed = true;
        }

    }
}

