using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SaveGame;
using RootMotion.FinalIK;
using QuestManager;
using UnityEngine.Playables;

namespace AI
{
    public class QuestNpc : AIAgent
    {
        [HideInInspector] public QuestGiver m_QuestGiver;
        [HideInInspector] public QuestReceiver m_QuestReceinver;

        [HideInInspector]public PlayableDirector m_PlayableDirector;
        public bool canInteract = true;
        LookAtIK lookAtComponent;
        public Transform lookAtTarget;
        [HideInInspector] public float headClamp;    // Reference to the maximum weight according to inspector values

        Transform eyes;
        // Saving Game
        //[HideInInspector] public GuardSaveComponent m_SaveComponent;

        public bool playerSaw = false;

        public void SetBlackboardValue(string valueName, int value)
        {
            m_Blackboard.SetIntValue(valueName, value);
        }

        public void SetBlackboardValue(string valueName, bool value)
        {
            m_Blackboard.SetBoolValue(valueName, value);
        }

        public void SetBlackboardValue(string valueName, Vector3 value)
        {
            m_Blackboard.SetVector3Value(valueName, value);
        }

        public int GetBlackboardIntValue(string valueName)
        {
            return m_Blackboard.GetIntValue(valueName);
        }

        public bool GetBlackboardBoolValue(string valueName)
        {       
            return m_Blackboard.GetBoolValue(valueName);
        }

        public void SetInteractionFalse()
        {

            canInteract = true;
        }

        public override void UpdateNavPoint()
        {
            throw new System.NotImplementedException();
        }

        public override void ReachNavPoint()
        {
            throw new System.NotImplementedException();
        }
            

        public void LookAtManager()
        {
            if (GetBlackboardBoolValue("playerSaw") == true)
            {
                
                lookAtComponent.solver.target = lookAtTarget;
                // Turn head speed
                if (lookAtComponent.solver.headWeight < headClamp)
                {
                    lookAtComponent.solver.headWeight += Time.deltaTime;
                }
            }
            //else
            //{
            //    lookAtComponent.solver.headWeight -= Time.deltaTime;
            //}
            
        }

        public void UpdateBlackBoard()
        {


            if (m_QuestGiver != null)
            {
                SetBlackboardValue("questAvailable", m_QuestGiver.myMission.available);
                SetBlackboardValue("questCompleted", m_QuestGiver.myMission.completed);

                SetBlackboardValue("questTurnInStatus", m_QuestGiver.myMission.turnInStatus);
            }
            else if (m_QuestGiver == null)
            {

                SetBlackboardValue("questAvailable", m_QuestReceinver.myMission.available);
                SetBlackboardValue("questCompleted", m_QuestReceinver.myMission.completed);

                SetBlackboardValue("questTurnInStatus", m_QuestReceinver.myMission.turnInStatus);
            }

            //Debug.Log("Quest : " + m_QuestGiver.myMission.available + " - " + m_QuestGiver.myMission.completed + " - " + m_QuestGiver.myMission.turnInStatus);
            //Debug.Log("Quest : " + GetBlackboardBoolValue("questAvailable") + " - " + GetBlackboardBoolValue("questCompleted") + " - " +
            //    GetBlackboardBoolValue("questTurnInStatus"));
        }

        public void SetQuestActive()
        {
            m_QuestGiver.myMission.active = true;
        }

        public void SetQuestTurnedIn()
        {
            m_QuestGiver.myMission.turnInStatus = true;
        }

        private void Awake()
        {
            m_NavMeshAgent = GetComponent<NavMeshAgent>();
            m_Animator = GetComponent<Animator>();
            m_Brain = GetComponent<Brain>();
            m_Brain.decisionMaker = Instantiate(m_Brain.decisionMaker);
            m_Brain.decisionMaker.m_Blackboard = new QuestNpcBlackboard();
            m_Blackboard = m_Brain.decisionMaker.m_Blackboard;
            m_Blackboard.m_Agent = this;

           // m_QuestGiver = GetComponent<QuestGiver>();
            m_PlayableDirector = GetComponent<PlayableDirector>();
            lookAtComponent = GetComponent<LookAtIK>();
        }

        private void Start()
        {
            //SetQuestAvailable();
            //SetQuestCompleted();
            //Debug.Log("Stop");
            //Debug.Log(m_QuestGiver.myMission.Obj);
        

        }

        private void Update()
        {
            LookAtManager();     
        }
    }

    
}

