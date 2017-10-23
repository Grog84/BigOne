﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveGame
{
    public class GuardSaveComponent : SaveObjComponent
    {

        private EnemiesAIStateController m_Controller;

        public enum GuardStates { Patrol, CheckPosition, Inactive }

        [HideInInspector] public GuardStates activeState;

        private void Awake()
        {
            m_Controller = GetComponent<EnemiesAIStateController>();
        }

        public override void LoadData()
        {
            base.LoadData();
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