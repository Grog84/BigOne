using System;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Linq;

namespace MissionManagerStuff
{
    [Serializable][HideMonoScript]
    public class MissionCreator : SerializedMonoBehaviour
    {

        [InfoBox("Selezionare Tipo Missione")]
        public MISSIONTYPE missionType;

    

        [DetailedInfoBox("Selezionare il grado di missione, premere per maggiorni info", "Missione Principale: Missione iniziale, e principale del livello, determina la condizione di vittoria;\n\n" +
        "Missione Subprimaria: Missione da completare prima della principale per completare la principale, completare prima le subprimarie;\n\n" +
        "Missioni Secondaria: Missioni Facoltaitve, possono facilitare o allungare la missione principale, compaiono sempre in fondo all'elenco delle missioni")]
        public MISSIONGRADE missionGrade;


        [InfoBox("Nome Missione")]
        public string missionName;


        [HideInInspector]
        public bool available;

        [HideInInspector]
        public bool completed;

        [Space]

        [InfoBox("Oggetto che ti consegna la quest")]
        [SceneObjectsOnly]
        [InlineEditor(InlineEditorModes.LargePreview)]
        public GameObject missionGiver;
        private Mission newMission;

        [ReadOnly]
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
        [InlineEditor(InlineEditorModes.LargePreview)]
        public GameObject pointA;

        [ShowIf("isAB")]
        [BoxGroup("Mission Type 0 Box")]
        [SceneObjectsOnly]
        [InlineEditor(InlineEditorModes.LargePreview)]
        public GameObject pointB;
        #endregion

        #region MissionType 1
        [BoxGroup("Mission Type 1 Box")]
        [ShowIf("isObj")]
          [SceneObjectsOnly]
        [InlineEditor(InlineEditorModes.LargePreview)]
        public GameObject Obj;

        [BoxGroup("Mission Type 1 Box")]
        [ShowIf("isObj")]
          [SceneObjectsOnly]
        [InlineEditor(InlineEditorModes.LargePreview)]
        public GameObject receiver;
        #endregion

        #region MissionType 2
        [BoxGroup("Mission Type 2 Box")]
        [ShowIf("isABTi")]
          [SceneObjectsOnly]
        [InlineEditor(InlineEditorModes.LargePreview)]
        public GameObject pointA_Timed;

        [BoxGroup("Mission Type 2 Box")]
        [ShowIf("isABTi")]
          [SceneObjectsOnly]
        [InlineEditor(InlineEditorModes.LargePreview)]
        public GameObject pointB_Timed;


        [BoxGroup("Mission Type 2 Box")]
        [ShowIf("isABTi")]
        public int time;
        #endregion
      
        
        private void Start()
        {

        }
        private void OnValidate()
        {
            if (missionType == MISSIONTYPE.SPOSTAMENTO_AB)
            {
                isAB = true;
                isObj = false;
                isABTi = false;
            }
            if (missionType == MISSIONTYPE.RICERCA_CONSEGNA_OGGETTO)
            {
                isAB = false;
                isObj = true;
                isABTi = false;
            }
            if (missionType == MISSIONTYPE.SPOSTAMENTO_AB_TIMED)
            {
                isAB = false;
                isObj = false;
                isABTi = true;
            }

        }
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        [Button("Aggiungi Quest", ButtonSizes.Medium)]
        public void CreateQuest()
        {
            bool error = false;
            if (missionName.Any(char.IsWhiteSpace) || missionName == "")
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
            if (missionType == MISSIONTYPE.SPOSTAMENTO_AB)
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
            if (missionType == MISSIONTYPE.RICERCA_CONSEGNA_OGGETTO)
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
            if (missionType == MISSIONTYPE.SPOSTAMENTO_AB_TIMED)
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

                Debug.Log("All field is valid, adding new mission, check MissionContainer for edit");
                QuestManager QuestManager =GetComponent<QuestManager>();
                
                newMission.missionName = this.missionName;
                newMission.missionType = this.missionType;
                newMission.missionGrade = this.missionGrade;
                newMission.missionGiver = this.missionGiver;
                newMission.available = this.available;
                newMission.completed = this.completed;
                newMission.Obj = this.Obj;
                newMission.pointA = this.pointA;
                newMission.pointA_Timed = this.pointA_Timed;
                newMission.pointB = this.pointB;
                newMission.pointB_Timed = this.pointB_Timed;
                newMission.receiver = this.receiver;
                newMission.time = this.time;
                newMission.missionIndex = this.missionIndex;
                missionIndex++;

                QuestManager.addNewMission(newMission);
            }

        }
    }

}