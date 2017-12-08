using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace MissionManagerStuff
{
    [Serializable]
    public class Mission
    {
        ////[ReadOnly]
        public string missionName;
        //[ReadOnly]
        [InfoBox("Nome Missione")]
        public MISSIONTYPE missionType;
        //[ReadOnly]
        public MISSIONGRADE missionGrade;
        //[ReadOnly]
        public int missionIndex;
        public bool ShowDescription;

        [ShowIf("ShowDescription")]
        //[ReadOnly]
        [TextArea]
        public string missionDescription;


        //[ReadOnly]
        public bool available;
        //[ReadOnly]
        public bool completed;

        [ReadOnly]
        public int SceneIndexNumber;
        ////[ReadOnly]
        public GameObject missionGiver;
        [HideInInspector]
        public bool Printed=false;
   [Space]
        [Space]
        private bool isAB;
        private bool isObj;
        private bool isABTi;
     

        #region MissionType 0

        [TabGroup("MissionTab", "AB_Mission")]
        //[ReadOnly]
        public GameObject pointA;

        [TabGroup("MissionTab", "AB_Mission")]
        //[ReadOnly]
        public GameObject pointB;
        #endregion

        #region MissionType 1
        [TabGroup("MissionTab", "Obj_Mission")]
        //[ReadOnly]
        public GameObject Obj;
        [TabGroup("MissionTab", "Obj_Mission")]
        //[ReadOnly]
        public GameObject receiver;
        #endregion

        #region MissionType 2
        [TabGroup("MissionTab", "ABTi_Mission")]
        //[ReadOnly]
        public GameObject pointA_Timed;
        [TabGroup("MissionTab", "ABTi_Mission")]
        //[ReadOnly]
        public GameObject pointB_Timed;

        [TabGroup("MissionTab", "ABTi_Mission")]
        //[ReadOnly]
        public int time;
        #endregion

        public Mission(string _missionName,MISSIONTYPE _missionType,MISSIONGRADE _missionGrade,string _missionDescription,int _missionIndex,GameObject _missionGiver, GameObject _pointA, GameObject _pointB, GameObject _obj, GameObject _receiver, GameObject _pointATi, GameObject _pointBTi,int _time,int _sceneIndexNumber)
        {

            missionName = _missionName;
            missionType = _missionType;
            missionGrade = _missionGrade;
            missionDescription = _missionDescription;
            missionIndex = _missionIndex;
            missionGiver = _missionGiver;
            pointA = _pointA;
            pointB = _pointB;
            Obj = _obj;
            receiver = _receiver;
            pointA_Timed = _pointATi;
            pointB_Timed = _pointBTi;
            time = _time;
            SceneIndexNumber = _sceneIndexNumber;
        }

    }

}