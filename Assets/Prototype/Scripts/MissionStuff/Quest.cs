using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace QuestManager
{
    [Serializable]
    public class Quest
    {
        ////[ReadOnly]
        public string questName;
        //[ReadOnly]
        
        public QUESTTYPE questType;
        //[ReadOnly]
        public QUESTGRADE questGrade;
        //[ReadOnly]
        public int questIndex;
        public bool ShowDescription;

        [ShowIf("ShowDescription")]
        //[ReadOnly]
        [TextArea]
        public string questDescription;


        //[ReadOnly]
        public bool available;

        public bool active;
        //[ReadOnly]
        public bool completed;

        public bool turnInStatus;

        [ReadOnly]
        public int SceneIndexNumber;
        ////[ReadOnly]
        public GameObject questGiver;
        [HideInInspector]
        public bool Printed=false;

        [Space(3f)]
       
        private bool isAB;
        private bool isObj;
        private bool isABTi;
        [HideInPlayMode]
        public bool isStriked = false;
        #region questType 0

        [TabGroup("questTab", "AB_quest")]
        //[ReadOnly]
        public GameObject pointA;

        [TabGroup("questTab", "AB_quest")]
        //[ReadOnly]
        public GameObject pointB;
        #endregion

        #region questType 1
        [TabGroup("questTab", "Obj_quest")]
        //[ReadOnly]
        public GameObject Obj;
        [TabGroup("questTab", "Obj_quest")]
        //[ReadOnly]
        public GameObject receiver;
        #endregion

        #region questType 2
        [TabGroup("questTab", "ABTi_quest")]
        //[ReadOnly]
        public GameObject pointA_Timed;
        [TabGroup("questTab", "ABTi_quest")]
        //[ReadOnly]
        public GameObject pointB_Timed;

        [TabGroup("questTab", "ABTi_quest")]
        //[ReadOnly]
        public int time;
        #endregion

        public Quest(string _questName,QUESTTYPE _questType,QUESTGRADE _questGrade,string _questDescription,int _questIndex,GameObject _questGiver, GameObject _pointA, GameObject _pointB, GameObject _obj, GameObject _receiver, GameObject _pointATi, GameObject _pointBTi,int _time,int _sceneIndexNumber)
        {

            questName = _questName;
            questType = _questType;
            questGrade = _questGrade;
            questDescription = _questDescription;
            questIndex = _questIndex;
            questGiver = _questGiver;
            pointA = _pointA;
            pointB = _pointB;
            Obj = _obj;
            receiver = _receiver;
            pointA_Timed = _pointATi;
            pointB_Timed = _pointBTi;
            time = _time;
            SceneIndexNumber = _sceneIndexNumber;
        }
        public void SetCompleted()
        {
            switch(questType)
            {

                case QUESTTYPE.RICERCA_CONSEGNA_OGGETTO:
                    completed = true;
                    //GetComponent<QuestNpc>().UpdateBlackboard();
                    
                    break;
                default: break;


            }

        }
    }

}