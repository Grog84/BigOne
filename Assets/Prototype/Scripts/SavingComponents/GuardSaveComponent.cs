using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace SaveGame
{
    public class GuardSaveComponent : SaveObjComponent
    {

        private EnemiesAIStateController m_Controller;

        [HideInInspector] public GuardStates activeState;

        public override void Awake()
        {
            base.Awake();
            m_Controller = GetComponent<EnemiesAIStateController>();

        }

        public override void LoadData()
        {
            base.LoadData();

            m_Controller.m_AgentController.hasHeardPlayer = false;
            m_Controller.m_AgentController.hasSeenPlayer = false;

            m_Controller.m_AgentController.m_Animator.SetFloat("Forward", 0f);

            activeState = (GuardStates)PlayerPrefs.GetInt(saveObjName + "status");
            switch (activeState)
            {
                case GuardStates.Patrol:
                    m_Controller.TransitionToState(m_Controller.patrolState);
                    m_Controller.m_AgentController.nextWayPoint = PlayerPrefs.GetInt(saveObjName + "nextWaypoint");
                    m_Controller.m_AgentController.checkingWayPoint = PlayerPrefs.GetInt(saveObjName + "currentWaypoint");
                    break;
                case GuardStates.CheckPosition:
                    m_Controller.m_AgentController.navPointTimer = PlayerPrefs.GetFloat(saveObjName + "navPointTimer");
                    m_Controller.m_AgentController.nextWayPoint = PlayerPrefs.GetInt(saveObjName + "nextWaypoint");
                    m_Controller.m_AgentController.checkingWayPoint = PlayerPrefs.GetInt(saveObjName + "currentWaypoint");
                    m_Controller.TransitionToState(m_Controller.checkNavPoint);
                    break;
                case GuardStates.Inactive:
                    m_Controller.TransitionToState(m_Controller.inactiveState);
                    break;
                default:
                    break;
            }
        }

        public override void SaveData()
        {
            base.SaveData();

            activeState = m_Controller.saveState;
            PlayerPrefs.SetInt(saveObjName + "status", (int)activeState);

            switch (activeState)
            {
                case GuardStates.Patrol:
                    PlayerPrefs.SetInt(saveObjName + "nextWaypoint", m_Controller.m_AgentController.nextWayPoint);
                    PlayerPrefs.SetInt(saveObjName + "currentWaypoint", m_Controller.m_AgentController.checkingWayPoint);
                    break;
                case GuardStates.CheckPosition:
                    PlayerPrefs.SetFloat(saveObjName + "navPointTimer", m_Controller.m_AgentController.navPointTimer);
                    PlayerPrefs.SetInt(saveObjName + "nextWaypoint", m_Controller.m_AgentController.nextWayPoint);
                    PlayerPrefs.SetInt(saveObjName + "currentWaypoint", m_Controller.m_AgentController.checkingWayPoint);
                    break;
                case GuardStates.Inactive:
                    break;
                default:
                    break;
            }
        }
    }
}