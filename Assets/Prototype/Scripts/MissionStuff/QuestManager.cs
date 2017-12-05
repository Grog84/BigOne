using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System.IO;

namespace MissionManagerStuff
{
    [Serializable][HideMonoScript]
    public class QuestManager : SerializedMonoBehaviour
    {
        string questPath;
        private Vector3 Giu = new Vector3 { x=0f, y=-70f, z=0f };
        private GameObject QuestMenu;


        public MissionContainer missionContainer;
        bool newMission = true;
      static  int  index = 1;
        // Use this for initialization
        private void Awake()
        {
            questPath= System.IO.Path.Combine(Application.persistentDataPath, "quest.json");
            QuestMenu = GameObject.Find("Pause_Quest");
            
        }
        void Start()
        {
            QuestMenu = GameObject.Find("Pause_Quest");
        }

        // Update is called once per frame
        void Update()
        {

            QuestMenu = GameObject.Find("Pause_Quest");
            //Debug.Log(QuestMenu.transform.position);
            checkIFnewMissionIsAvailable();
        }

        private void checkIFnewMissionIsAvailable()
        {
           foreach(Mission m in missionContainer.MissionList)
            {
                if(m.available)
                {
                    Debug.Log("Disponibile la missione :" + m.missionName);
                }

            }
        }

        public void addNewMission(Mission newMission)
        {
            missionContainer.MissionList.Add(newMission);  
            
        }
        [PropertyOrder(0)]
        [Button("ClearList")]
        public void Clear()
        {
            missionContainer.MissionList.Clear();

        }
        [PropertyOrder(-2)]
        [HideInEditorMode]
        [Button("Salva Quest",ButtonSizes.Medium)]
        public void Save()
        {

            SaveMission(missionContainer);
            
        }
        private void OnApplicationQuit()
        {
            Save();
        }
        [PropertyOrder(-1)]
        [Button("Prova",ButtonSizes.Medium)]
        public void ShowActiveQuestOnMenu()
        {
            if (newMission)
            {
                QuestMenu = GameObject.Find("Pause_Quest");
                QuestMenu.GetComponent<GameObject>();
                foreach (Mission M in missionContainer.MissionList)
                {
                    Debug.Log(QuestMenu.transform.position);
                    Instantiate(
                        QuestMenu.transform.GetChild(QuestMenu.transform.childCount - 1).gameObject,
                        QuestMenu.transform)
                        .transform.position += Giu;

                    QuestMenu.transform.GetChild(index).gameObject.SetActive(true);
                    Text Testo = QuestMenu.transform.GetChild(index).GetComponent<Text>();
                    Testo.text = M.missionName;
                    index++;
                }
                newMission = false;
            }
          
        
        }
        
        public void SaveMission(MissionContainer MC)
        {

            string json = JsonUtility.ToJson(MC);

            StreamWriter sw = File.CreateText(questPath);
            sw.Close();

            File.WriteAllText(questPath, json);
              

        }

       
    }
}

