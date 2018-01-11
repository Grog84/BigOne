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
 
        
        public QUESTTYPE questType;
    
        public QUESTGRADE questGrade;
 
        public int questIndex;
        public bool ShowDescription;

        [ShowIf("ShowDescription")]
    
        [TextArea]
        public string questDescription;

        
        public bool available;

        public bool active;

       
        public bool completed;

        public bool turnInStatus;

        [ReadOnly]
        public int SceneIndexNumber;
       
        public GameObject questGiver;
      
        public bool Printed=false;

        [Space(3f)]
       
        private bool isAB;
        private bool isObj;
        private bool isABTi;
 
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
        public float time;
        #endregion
        [HideInInspector]
        public int backUpTime;
        [HideInInspector]
        public string pointA_ObjName;
        [HideInInspector]
        public string pointB_ObjName;
        [HideInInspector]
        public string Obj_ObjName;
        [HideInInspector]
        public string receiver_ObjName;
       [HideInInspector]
        public string pointATimed_ObjName;
     [HideInInspector]
        public string pointBTimed_ObjName;
        [HideInInspector]
        public string questGiver_ObjName;

        public Quest(string _questName,QUESTTYPE _questType,QUESTGRADE _questGrade,string _questDescription,int _questIndex,GameObject _questGiver, GameObject _pointA, GameObject _pointB, GameObject _obj, GameObject _receiver, GameObject _pointATi, GameObject _pointBTi,float _time,int _sceneIndexNumber)
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
            backUpTime = (int)time;
        }

        public void SetCompleted()
        {
            Debug.Log("Set completed");
            switch(questType)
            {

                case QUESTTYPE.RICERCA_CONSEGNA_OGGETTO:
                    completed = true;
                    receiver.GetComponent<QuestNpc>().UpdateBlackBoard();
                    break;


                case QUESTTYPE.SPOSTAMENTO_AB:
                    completed = true;

                    break;
                       
                case QUESTTYPE.SPOSTAMENTO_AB_TIMED:
                    completed = true;

                    break;
                default: break;


            }

        }

        public void SetActive()
        {
            active = true;
        }
    }

}