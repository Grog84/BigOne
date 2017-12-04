using System;
using System.Collections;
using UnityEngine;using Sirenix.OdinInspector;


namespace MissionManagerStuff
{
    [Serializable][HideMonoScript]
    public class QuestManager : SerializedMonoBehaviour
    {

        public MissionContainer missionContainer;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
       
        }

        public void addNewMission(Mission newMission)
        {
            missionContainer.MissionList.Add(newMission);           
        }


       
    }
    [Serializable]
    public enum MISSIONTYPE
    {
        SPOSTAMENTO_AB,
        RICERCA_CONSEGNA_OGGETTO,
        SPOSTAMENTO_AB_TIMED
    }

    [Serializable]
    public enum MISSIONGRADE
    {
        PRIMARIA, SUBPRIMARIA, SECONDARIA

    }
}

