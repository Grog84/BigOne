using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSaveComponent : SaveObjComponent
{

    private _AgentController m_AgentController;

    private void Awake()
    {
        m_AgentController = GetComponent<_AgentController>();
    }

    public override void LoadData()
    {
        base.LoadData();
        
    }

    public override void SaveData()
    {
        base.SaveData();
    }
}
