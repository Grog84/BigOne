using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace QuestManager
{
    public class QuestObject:SerializedMonoBehaviour
    {
        [HideInInspector]
        public Quest m_Mission;
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

