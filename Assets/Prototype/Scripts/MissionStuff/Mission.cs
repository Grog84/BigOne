using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace MissionManagerStuff
{
    [Serializable]
    public class Mission
    {
        [ReadOnly]
        public string missionName;
        [ReadOnly]
        public MISSIONTYPE missionType;
        [ReadOnly]
        public MISSIONGRADE missionGrade;
        [ReadOnly]
        public int missionIndex;

        [ReadOnly]
        public bool available;
        [ReadOnly]
        public bool completed;
        [ReadOnly]
        public GameObject missionGiver;
   [Space]
        [Space]
        private bool isAB;
        private bool isObj;
        private bool isABTi;
     

        #region MissionType 0

        [TabGroup("MissionTab", "AB_Mission")]
        [ReadOnly]
        public GameObject pointA;

        [TabGroup("MissionTab", "AB_Mission")]
        [ReadOnly]
        public GameObject pointB;
        #endregion

        #region MissionType 1
        [TabGroup("MissionTab", "Obj_Mission")]
        [ReadOnly]
        public GameObject Obj;
        [TabGroup("MissionTab", "Obj_Mission")]
        [ReadOnly]
        public GameObject receiver;
        #endregion

        #region MissionType 2
        [TabGroup("MissionTab", "ABTi_Mission")]
        [ReadOnly]
        public GameObject pointA_Timed;
        [TabGroup("MissionTab", "ABTi_Mission")]
        [ReadOnly]
        public GameObject pointB_Timed;

        [TabGroup("MissionTab", "ABTi_Mission")]
        [ReadOnly]
        public int time;
        #endregion

        Mission()
        {


        }

    }

}