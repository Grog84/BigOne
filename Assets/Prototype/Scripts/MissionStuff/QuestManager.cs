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
        
        public bool CreateMission;
        #region MissionCreator
        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [InfoBox("Selezionare Tipo Missione")]
        public QUESTTYPE missionType;


        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [DetailedInfoBox("Selezionare il grado di missione, premere per maggiorni info", "Missione Principale: Missione iniziale, e principale del livello, determina la condizione di vittoria;\n\n" +
        "Missione Subprimaria: Missione da completare prima della principale per completare la principale, completare prima le subprimarie;\n\n" +
        "Missioni Secondaria: Missioni Facoltaitve, possono facilitare o allungare la missione principale, compaiono sempre in fondo all'elenco delle missioni")]
        public QUESTGRADE missionGrade;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [InfoBox("Nome Missione")]
        public string missionName;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [InfoBox("Attivare per inserire Descrizione")]
        public bool NeedDescription;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [ShowIf("NeedDescription")]
        [TextArea]
        public string missionDescription;

        [HideInInspector]
        public bool available;

        [HideInInspector]
        public bool completed;

        [Space]
        [Header("Mission Objective")]
        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [InfoBox("Oggetto che ti consegna la quest")]
        [SceneObjectsOnly]
        public GameObject missionGiver;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [HideInInspector]
        [ReadOnly]
        public int SceneIndexNumber;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        public int missionIndex;

        private bool isAB;
        private bool isObj;
        private bool isABTi;

        [Space]
        [Space]

        #region MissionType 0
        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [ShowIf("isAB")]

        [SceneObjectsOnly]
        public GameObject pointA;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [ShowIf("isAB")]

        [SceneObjectsOnly]
        public GameObject pointB;
        #endregion

        [Space]
        [Space]
        #region MissionType 1
        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]

        [ShowIf("isObj")]
        [SceneObjectsOnly]
        public GameObject Obj;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]

        [ShowIf("isObj")]
        [SceneObjectsOnly]
        public GameObject receiver;
        #endregion

        [Space]
        [Space]
        #region MissionType 2
        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [ShowIf("isABTi")]
        [SceneObjectsOnly]
        public GameObject pointA_Timed;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [ShowIf("isABTi")]
        [SceneObjectsOnly]
        public GameObject pointB_Timed;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [ShowIf("isABTi")]
        public float time;
        #endregion

        private bool isStriked = false;

        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [Button("Reset Index Missioni", ButtonSizes.Medium)]
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
        [BoxGroup("MissionCreator")]
        [ShowIf("CreateMission")]
        [GUIColor(0.8f, 0.5f, 0.7f, 1f)]
        [Button("Aggiungi Quest", ButtonSizes.Gigantic)]
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
                 QC.QuestList.Add(new Quest(this.missionName, this.missionType, this.missionGrade, this.missionDescription, this.missionIndex, this.missionGiver, this.pointA, this.pointB, this.Obj, this.receiver, this.pointA_Timed, this.pointB_Timed, this.time, SceneIndexNumber));
                missionIndex++;
                SaveQuestGameObjectName();
            }

        }
        #endregion

        private bool IsCorrect;
        private string questPath;
        private Vector3 Giu = new Vector3 { x = 0f, y = -80f, z = 0f };
        [Space]

        [InfoBox("Collegare il Canvas: 'pause_Quest' Dentro Canvas =>Canvas_Pause")]
        [InfoBox("Non Valido", InfoMessageType.Error, "IsCorrect")]
        public GameObject QuestMenu;
   
        [Space]
        [Space]
        [Header("Quest Container")]
        [InfoBox("Inserire il proprio Contenitore di Quest, Scriptable object da creare",InfoMessageType.None)]
        [AssetList(Path ="Prototype/ScriptableObjects/LevelQuest/")]
        public QuestContainer QC;
        string dataPath;

        static int index = 1;
        GameObject Timer;
     public bool ResettoAllaChiusura;
      //  Use this for initialization
        private void Awake()
        {
            questPath = System.IO.Path.Combine(Application.persistentDataPath, "quest.json");
            dataPath = System.IO.Path.Combine(Application.persistentDataPath, "quest.json");
            ActivatePrimaryQuests();
        }

        void Start()
        {
            LoadQuestGameObjectName();
            AssignQuestToQuestGivers();
            InizializeQuestPoint();
            InitializedQuestObject();
            InizializedQuestReceiver();
            Timer = GameObject.Find("Timer");
            Timer.SetActive(false);
        }
        //Update is called once per frame
        void Update()
        {
            timerDown();
            checkIFnewMissionIsAvailable();
        }

        private void timerDown()
        {
           
          
            foreach(Quest q in QC.QuestList)
            {
                if (q.questType == QUESTTYPE.SPOSTAMENTO_AB_TIMED)
                {
                    if (q.active)
                    {
                        Timer.SetActive(true);
                        if (!q.completed)
                        {
                            if (q.time > 0)
                            {
                                q.time -= Time.deltaTime;
                            }
                            if (q.time < 0)
                            {
                                Debug.Log("Snake, rispondimi Snake, SNAKE, SNAKEEEEEEEEEEEEEEE!!!");
                                q.time = q.backUpTime;
                                GMController.instance.LoadCheckpoint();
                            }
                            Timer.GetComponent<Text>().text =Mathf.Round(q.time).ToString();
                        }
                    }
                }
            }
        }



      public Text Testo;
        private void checkIFnewMissionIsAvailable()
        {
           
            foreach (Quest m in QC.QuestList)
            {
                if (m.active)
                {
                    if (!m.Printed)
                    {
                        Instantiate(QuestMenu.transform.GetChild(QuestMenu.transform.childCount - 1).gameObject,QuestMenu.transform).transform.position += Giu;
                        m.Printed = true;                      
                        QuestMenu.transform.GetChild(index).gameObject.SetActive(true);
                        index++;
                        Testo = QuestMenu.transform.GetChild(index - 1).GetComponent<Text>();                 
                        Testo.text = m.questName;                 
                    }
                    if (m.Printed)
                    {
                        if (m.completed)
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
            foreach (Quest q in QC.QuestList)
            {
                if (q.questGrade == QUESTGRADE.PRIMARIA)
                {
                    q.available = true;
                }
            }
        }

        private void AssignQuestToQuestGivers()
        {
          
            foreach (Quest m in  QC.QuestList)
            {               
                QuestGiver QG;
                QG = m.questGiver.gameObject.GetComponent<QuestGiver>();
                if (QG == null)
                { QG = m.questGiver.gameObject.AddComponent<QuestGiver>();   }

                QG.myMission = m;
                QG.missionIndex = m.questIndex;

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
            
        public void InitializedQuestObject()
        {
            foreach (Quest m in  QC.QuestList)
            {
                if (m.questType == QUESTTYPE.RICERCA_CONSEGNA_OGGETTO)
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

        }

        public void InizializedQuestReceiver()
        {
            foreach (Quest m in  QC.QuestList)
            {
                if(m.questType== QUESTTYPE.RICERCA_CONSEGNA_OGGETTO)
                {

                if (m.receiver.GetComponent<QuestReceiver>() == null)
                {
                    m.receiver.AddComponent<QuestReceiver>();
                }
                m.receiver.GetComponent<QuestReceiver>().myMission = m;

                    QuestNpc QNPC;
                    QNPC = m.receiver.gameObject.GetComponent<QuestNpc>();
                    QNPC.m_QuestReceiver = m.receiver.gameObject.GetComponent<QuestReceiver>();
                    QNPC.m_QuestReceiver.myMission = m;
                    if (QNPC != null)
                    {
                        QNPC.UpdateBlackBoard();
                    }
                }
            }
        }

        public void InizializeQuestPoint()
        {
            foreach(Quest m in QC.QuestList)
            {
                if(m.questType== QUESTTYPE.SPOSTAMENTO_AB)
                {
                    if (m.pointA.GetComponent<QuestPoint>() == null)
                    {
                        m.pointA.AddComponent<QuestPoint>();
                    }
                    m.pointA.GetComponent<QuestPoint>().m_Quest=m;
                    m.pointA.GetComponent<QuestPoint>().m_Point = POINT.POINT_A;
                   
                    if (m.pointB.GetComponent<QuestPoint>() == null)
                    {
                        m.pointB.AddComponent<QuestPoint>();
                    }
                    m.pointB.GetComponent<QuestPoint>().m_Quest = m;
                    m.pointB.GetComponent<QuestPoint>().m_Point = POINT.POINT_B;
                }
                if (m.questType == QUESTTYPE.SPOSTAMENTO_AB_TIMED)
                {
                    if (m.pointA_Timed.GetComponent<QuestPoint>() == null)
                    {
                        m.pointA_Timed.AddComponent<QuestPoint>();
                    }
                    m.pointA_Timed.GetComponent<QuestPoint>().m_Quest = m;
                    m.pointA_Timed.GetComponent<QuestPoint>().m_Point = POINT.POINT_A;

                    if (m.pointB_Timed.GetComponent<QuestPoint>() == null)
                    {
                        m.pointB_Timed.AddComponent<QuestPoint>();
                    }
                    m.pointB_Timed.GetComponent<QuestPoint>().m_Quest = m;
                    m.pointB_Timed.GetComponent<QuestPoint>().m_Point = POINT.POINT_B;
                }

            }

        }

        public void SaveQuestGameObjectName()
        {
            foreach(Quest q in QC.QuestList)
            {
                q.questGiver_ObjName = q.questGiver.name;
                switch(q.questType)
                {
                    case QUESTTYPE.RICERCA_CONSEGNA_OGGETTO:
                        if(q.Obj != null)
                            q.Obj_ObjName = q.Obj.name;
                        if (q.receiver != null)
                            q.receiver_ObjName = q.receiver.name;
                        break;
                    case QUESTTYPE.SPOSTAMENTO_AB:
                        if (q.pointA != null)
                            q.pointA_ObjName = q.pointA.name;
                        if (q.pointA != null)
                            q.pointA_ObjName = q.pointA.name;
                        break;
                    case QUESTTYPE.SPOSTAMENTO_AB_TIMED:
                        if (q.pointA_Timed != null)
                            q.pointATimed_ObjName = q.pointA_Timed.name;
                        if (q.pointB_Timed != null)
                            q.pointBTimed_ObjName = q.pointB_Timed.name;
                        break;
                }

            }
        }
       
        public void LoadQuestGameObjectName()
        {
            foreach (Quest q in QC.QuestList)
            {
                q.questGiver = GameObject.Find(q.questGiver_ObjName);
                switch (q.questType)
                {
                    case QUESTTYPE.RICERCA_CONSEGNA_OGGETTO:
                        q.Obj = GameObject.Find(q.Obj_ObjName);
                        q.receiver = GameObject.Find(q.receiver_ObjName);
                        break;
                    case QUESTTYPE.SPOSTAMENTO_AB:
                     q.pointA = GameObject.Find(q.pointA_ObjName);
                        q.pointB = GameObject.Find(q.pointB_ObjName);
                        break;
                    case QUESTTYPE.SPOSTAMENTO_AB_TIMED:
                      q.pointA_Timed = GameObject.Find(q.pointATimed_ObjName);
                        q.pointB_Timed = GameObject.Find(q.pointBTimed_ObjName);
                        break;
                }
            }
        }

        public void SaveQuest()
        {
            string questSave = JsonUtility.ToJson(QC);
            SaveData.SaveQuestContainer(dataPath, questSave);
        }

        private void OnApplicationQuit()
        {
            foreach (Quest m in QC.QuestList)
            {
                if (ResettoAllaChiusura)
                {
                    m.Reset();
                }
                m.Printed = false;
            }
            SaveQuestGameObjectName();
            SaveQuest();
        }
    }
}


