using System;
using UnityEngine;
using Sirenix.OdinInspector;
using AI;


namespace QuestManager
{
    [Serializable]
    public class Quest
    {

        public string questName;
        public GameObject questGiver;
        public GameObject questFinisher;
        public bool active;
        public bool inactive;
        public bool completed;

        public Quest(string _questName, GameObject _questGiver, GameObject _questFinisher)
        {
            questName = _questName;
            questGiver = _questGiver;
            questFinisher = _questFinisher;
           
        }
        public void Reset()
        {
            completed = false;
            active = false;
            inactive = false;
        }
        public void SetActive()
        {
            active = true;
            inactive = false;
        }
        public void SetInactive()
        {
            inactive = true;
            active = false;
        }
        public void SetCompleted()
        {
            active = false;
            inactive = false;
            completed = true;
        }


    }

}