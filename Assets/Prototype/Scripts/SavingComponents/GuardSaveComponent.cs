using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
                break;
            case GuardStates.CheckPosition:
                m_Controller.m_AgentController.navPointTimer = PlayerPrefs.GetFloat(saveObjName + "navPointTimer");
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

        if (activeState == GuardStates.CheckPosition)
        {
            PlayerPrefs.SetFloat(saveObjName + "navPointTimer", m_Controller.m_AgentController.navPointTimer);
        }
    }
}
