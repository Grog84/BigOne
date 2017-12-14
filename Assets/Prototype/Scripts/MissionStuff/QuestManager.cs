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


        #region MissionCreator


        [InfoBox("Selezionare Tipo Missione")]
        public QUESTTYPE missionType;



        [DetailedInfoBox("Selezionare il grado di missione, premere per maggiorni info", "Missione Principale: Missione iniziale, e principale del livello, determina la condizione di vittoria;\n\n" +
        "Missione Subprimaria: Missione da completare prima della principale per completare la principale, completare prima le subprimarie;\n\n" +
        "Missioni Secondaria: Missioni Facoltaitve, possono facilitare o allungare la missione principale, compaiono sempre in fondo all'elenco delle missioni")]
        public QUESTGRADE missionGrade;


        [InfoBox("Nome Missione")]
        public string missionName;


        [InfoBox("Attivare per inserire Descrizione")]
        public bool NeedDescription;

        [ShowIf("NeedDescription")]
        [TextArea]
        public string missionDescription;

        [HideInInspector]
        public bool available;

        [HideInInspector]
        public bool completed;

        [Space]

        [InfoBox("Oggetto che ti consegna la quest")]
        [SceneObjectsOnly]
        public GameObject missionGiver;

        [HideInInspector]
        [ReadOnly]
        public int SceneIndexNumber;

        //[ReadOnly]
        public int missionIndex;

        private bool isAB;
        private bool isObj;
        private bool isABTi;

        [Space]
        [Space]
        #region MissionType 0
        [ShowIf("isAB")]
        [BoxGroup("Mission Type 0 Box")]
        [SceneObjectsOnly]
        public GameObject pointA;

        [ShowIf("isAB")]
        [BoxGroup("Mission Type 0 Box")]
        [SceneObjectsOnly]
        public GameObject pointB;
        #endregion

        #region MissionType 1
        [BoxGroup("Mission Type 1 Box")]
        [ShowIf("isObj")]
        [SceneObjectsOnly]
        public GameObject Obj;

        [BoxGroup("Mission Type 1 Box")]
        [ShowIf("isObj")]
        [SceneObjectsOnly]
        public GameObject receiver;
        #endregion

        #region MissionType 2
        [BoxGroup("Mission Type 2 Box")]
        [ShowIf("isABTi")]
        [SceneObjectsOnly]
        public GameObject pointA_Timed;

        [BoxGroup("Mission Type 2 Box")]
        [ShowIf("isABTi")]
        [SceneObjectsOnly]
        public GameObject pointB_Timed;


        [BoxGroup("Mission Type 2 Box")]
        [ShowIf("isABTi")]
        public int time;
        #endregion

        private bool isStriked = false;

        [Button("Reset Index Missioni",ButtonSizes.Medium)]
        public void resetIndex()
        {
            missionIndex = 0;
        }

        private void OnValidate()
        {
          
            if (missionType == QUESTTYPE.SPOSTAMENTO_AB)
            {
                isAB = true;
                isObj = false;
                isABTi = false;
            }
            if (missionType == QUESTTYPE.RICERCA_CONSEGNA_OGGETTO)
            {
                isAB = false;
                isObj = true;
                isABTi = false;
            }
            if (missionType == QUESTTYPE.SPOSTAMENTO_AB_TIMED)
            {
                isAB = false;
                isObj = false;
                isABTi = true;
            }
          
            SceneIndexNumber = SceneManager.GetActiveScene().buildIndex;
        }

        QuestManager QM;

        [GUIColor(0.8f, 0.3f, 0.8f, 1f)]
        [PropertyOrder(-1)]
        [Button("Aggiungi Quest", ButtonSizes.Medium)]

        public void CreateQuest()
        {
            bool error = false;
            if (missionName == "")
            {
                Debug.LogError("Invalid: Mission as no name assigned");
                error = true;
            }
            if (completed == true)
            {
                Debug.LogError("Invalid: Completed already true");
                error = true;
            }
            if (missionGiver == null)
            {
                Debug.LogError("Invalid: No Mission Giver Assigned");
                error = true;
            }
            if (missionType == QUESTTYPE.SPOSTAMENTO_AB)
            {
                if (pointA == null)
                {
                    Debug.LogError("Invalid: Point A is Null");
                    error = true;
                }
                if (pointB == null)
                {
                    Debug.LogError("Invalid: Point B is Null");
                    error = true;
                }
            }
            if (missionType == QUESTTYPE.RICERCA_CONSEGNA_OGGETTO)
            {
                if (Obj == null)
                {
                    Debug.LogError("Invalid: Obj is Null");
                    error = true;
                }
                if (receiver == null)
                {
                    Debug.LogError("Invalid : Receiver is Null");
                    error = true;
                }
            }
            if (missionType == QUESTTYPE.SPOSTAMENTO_AB_TIMED)
            {
                if (pointA_Timed == null)
                {
                    Debug.LogError("Invalid: Point A Timed is Null");
                    error = true;
                }
                if (pointB_Timed == null)
                {
                    Debug.LogError("Invalid: Point B Timed is Null");
                    error = true;
                }
                if (time == 0)
                {
                    Debug.LogError("Invalid: Time is not setted");
                    error = true;

                }
            }

            if (!error)
            {
                SceneIndexNumber = SceneManager.GetActiveScene().buildIndex;
                Debug.Log("All field is valid, adding new mission, check MissionContainer for edit");
                MissionList.Add(new Quest(this.missionName, this.missionType, this.missionGrade, this.missionDescription, this.missionIndex, this.missionGiver, this.pointA, this.pointB, this.Obj, this.receiver, this.pointA_Timed, this.pointB_Timed, this.time,SceneIndexNumber));
                missionIndex++;
              
            }

        }
        #endregion

        private bool IsCorrect;
        private string questPath;
        private Vector3 Giu = new Vector3 { x=0f, y=-80f, z=0f };

        [InfoBox("Collegare il Canvas: 'pause_Quest' Dentro Canvas =>Canvas_Pause")]
        [InfoBox("Non Valido", InfoMessageType.Error, "IsCorrect")]
        public GameObject QuestMenu;
        Text Testo;
        public List<Quest> MissionList;
        //public MissionContainer missionContainer;
       
        static  int  index = 1;
        // Use this for initialization
        private void Awake()
        {      
   //         QuestMenu = GameObject.Find("Pause_Quest");
            questPath= System.IO.Path.Combine(Application.persistentDataPath, "quest.json");
            ActivatePrimaryQuests();
        }

        void Start()
        {
            AssignQuestToQuestGivers();
            InitializedQuestObject();
            InizializedQuestReceiver();
        }


        // Update is called once per frame
        void Update()
        {
           checkIFnewMissionIsAvailable();
        }
        
        
        private void checkIFnewMissionIsAvailable()
        {
           foreach(Quest m in MissionList)
            {
                if(m.available)
                {
                    if (!m.Printed)
                    {
                      
                        Instantiate(
                             QuestMenu.transform.GetChild(QuestMenu.transform.childCount - 1).gameObject,
                             QuestMenu.transform)
                             .transform.position += Giu;
                        QuestMenu.transform.GetChild(index).gameObject.SetActive(true);
                         Testo = QuestMenu.transform.GetChild(index).GetComponent<Text>();
                        Testo.text = m.questName;
                        index++;
                        m.Printed = true;
                      
                    }
                    if(m.Printed)
                    {
                        if(m.completed)
                        {
                            if (!m.isStriked)
                            {
                                Testo.text = StrikeThrough(Testo.text);
                                m.isStriked = true;
                             
                            }
                        }
                    }
                }
                
            }
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

        private void ActivatePrimaryQuests()
        {
            foreach (Quest q in MissionList)
            {
                q.available = true;
            }

        }

        private void AssignQuestToQuestGivers()
        {
            int i = 0;
            foreach (Quest m in MissionList)
            {
                Debug.Log(i);
                i++;
                QuestGiver QG;
                QG = m.questGiver.gameObject.GetComponent<QuestGiver>();
                if (QG == null)
                {
                    QG = m.questGiver.gameObject.AddComponent<QuestGiver>();
                }

                QG.myMission = m;
                QG.missionIndex = m.questIndex;

                QuestNpc QNPC;
                QNPC = m.questGiver.gameObject.GetComponent<QuestNpc>();
                if (QNPC != null)
                {
                    QNPC.UpdateBlackBoard();
                }
            }
        }
        
        [PropertyOrder(-2)]
        [HideInEditorMode]
        [Button("Salva Quest",ButtonSizes.Medium)]
        public void Save()
        {
            SaveMission(MissionList);            
        }
        private void OnApplicationQuit()
        {
            Save();
        }
        
                
        public void SaveMission(List<Quest> missionList)
        {

            string json = JsonUtility.ToJson(missionList);

            StreamWriter sw = File.CreateText(questPath);
            sw.Close();

            File.WriteAllText(questPath, json);
              

        }
        public void InitializedQuestObject()
        {
            foreach (Quest m in MissionList)
            {
                QuestObject QObj;
                QObj = m.Obj.GetComponent<QuestObject>();
                if (QObj == null)
                {
                    QObj = m.Obj.AddComponent<QuestObject>();
                }
                QObj.m_Name = m.Obj.gameObject.name;
                QObj.m_Mission = m;
            }
          
        }

        public void InizializedQuestReceiver()
        {
            foreach (Quest m in MissionList)
            {               
                    if (m.receiver.GetComponent<QuestReceiver>() == null)
                    {
                        m.receiver.AddComponent<QuestReceiver>();
                    }
                    m.receiver.GetComponent<QuestReceiver>().myMission = m;  
            }
        }
       
    }
}

