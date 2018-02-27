using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using AI;

namespace QuestManager
{
    [Serializable]
    public class QuestManager : SerializedMonoBehaviour
    {
        public bool CreateObjective;
        #region MissionCreator
    
        [BoxGroup("ObjectiveCreator")]
        [ShowIf("CreateObjective")]
        [InfoBox("Nome Obbiettivo")]
        public string objectiveName;
                
        [HideInInspector]
        public bool available;

        [HideInInspector]
        public bool completed;

        [Space]
        [Header("Mission Objective")]
        [BoxGroup("ObjectiveCreator")]
        [ShowIf("CreateObjective")]
        [InfoBox("Oggetto che ti consegna la quest")]
        [SceneObjectsOnly]
        public GameObject objectiveGiver;      

        [BoxGroup("ObjectiveCreator")]
        [ShowIf("CreateObjective")]
        [InfoBox("Oggetto che ti termina la quest")]
        [SceneObjectsOnly]
        public GameObject objectiveFinish;


        [BoxGroup("ObjectiveCreator")]
        [ShowIf("CreateObjective")]
        [HideInInspector]
        [ReadOnly]
        public int SceneIndexNumber;

         private bool isStriked = false;


        QuestManager QM;
        [BoxGroup("ObjectiveCreator")]
        [ShowIf("CreateObjective")]
        [GUIColor(0.8f, 0.5f, 0.7f, 1f)]
        [Button("Aggiungi Quest", ButtonSizes.Gigantic)]
        public void CreateQuest()
        {
            QC.QuestList.Add(new Quest(objectiveName, objectiveGiver, objectiveFinish));
        }
        #endregion

        private bool IsCorrect;
        private string questPath;
        private Vector3 Giu = new Vector3 { x = 0f, y = -80f, z = 0f };
        [Space]      
        
        [Header("Objective Container")]
        [InfoBox("Inserire il proprio Contenitore di Quest, Scriptable object da creare", InfoMessageType.None)]
        [AssetList(Path = "Prototype/ScriptableObjects/LevelQuest/")]
        public QuestContainer QC;
        string dataPath;

     
        GameObject Timer;
        public bool ResettoAllaChiusura;
        public Text Testo;


        //  Use this for initialization
        private void Awake()
        {
            questPath = System.IO.Path.Combine(Application.persistentDataPath, "quest.json");
            dataPath = System.IO.Path.Combine(Application.persistentDataPath, "quest.json");            
            
        }
        public void Start()
        {
            AssignQuestToObjectiveStarter();
            AssignQuestToObjectiveFinisher();
            ActivateIndexQuest(0);
        }

        
        public string StrikeThrough(string s)
        {
            string strikethrough = "";
            foreach (char c in s)
            {
                strikethrough = strikethrough + c + '\u0336';
            }
            return strikethrough;
        }

        public void SaveQuest()
        {
            string questSave = JsonUtility.ToJson(QC);
            //SaveData.SaveQuestContainer(dataPath, questSave);
        }

        private void OnApplicationQuit()
        {
            foreach (Quest m in QC.QuestList)
            {
                if (ResettoAllaChiusura)
                {
                    m.Reset();
                }             
            }          
            SaveQuest();
        }

        private void AssignQuestToObjectiveStarter()
        {

            foreach (Quest m in QC.QuestList)
            {
                QuestGiver QG;
                QG = m.questGiver.gameObject.GetComponent<QuestGiver>();
                if (QG == null)
                {
                    QG = m.questGiver.gameObject.AddComponent<QuestGiver>();
                }

                QG.myMission = m;

                if (m.questGiver.GetComponent<QuestNpc>() != null)
                {
                    QuestNpc QNPC;
                    QNPC = m.questGiver.gameObject.GetComponent<QuestNpc>();
                    QNPC.m_QuestGiver = m.questGiver.gameObject.GetComponent<QuestGiver>();
                    QNPC.m_QuestGiver.myMission = m;
                    if (QNPC != null)
                    {
                        QNPC.UpdateBlackBoard();
                    }
                }
            }
        }

        private void AssignQuestToObjectiveFinisher()
        {

            foreach (Quest m in QC.QuestList)
            {
                ObjectiveFinisher OF;
                OF = m.questFinisher.gameObject.GetComponent<ObjectiveFinisher>();
                if (OF == null)
                {
                    OF = m.questFinisher.gameObject.AddComponent<ObjectiveFinisher>();
                }

                OF.myMission = m;
              

                
            }
        }
        int next;
        public void ActivateNextObjective()
        {
            for (int i = 0; i <QC.QuestList.Count; i++)
            {
                if (QC.QuestList[i].active)
                {
                    QC.QuestList[i].SetCompleted();
                    next = i;

                }              

            }
            QC.QuestList[next++].SetActive();
        }
        public void ActivateIndexQuest(int missione)
        {
            foreach (Quest Q in QC.QuestList)
            {
                if (Q.active)
                {
                    Q.SetInactive();
                }
            }
            if (missione <= QC.QuestList.Count)
            {
                QC.QuestList[missione].SetActive();
                Testo.text = QC.QuestList[missione].questName;
            }
        }
    }
}


