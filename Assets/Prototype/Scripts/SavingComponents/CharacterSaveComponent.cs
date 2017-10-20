using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSaveComponent : SaveObjComponent
{

    private CharacterStateController m_Controller;

    private void Awake()
    {
        m_Controller = GetComponent<CharacterStateController>();
    }

    public override void LoadData()
    {
        base.LoadData();
        m_Controller.TransitionToState(m_Controller.gameStartState);


    }

    public override void SaveData()
    {
        base.SaveData();
    }
}
