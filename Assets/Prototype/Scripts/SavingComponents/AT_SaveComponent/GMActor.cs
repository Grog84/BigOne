using UnityEngine;
using StateMachine;
using AI;

public class GMActor : Actor
{
    GMController m_Controller;

    CharacterActive m_CharActive;

    public override void Awake()
    {
        base.Awake();
        m_Controller = GetComponent<GMController>();
    }
    public override void StoreData()
    {
        base.StoreData();
        m_CharActive = m_Controller.isCharacterPlaying;
    }


    public override void LoadData()
    {
        base.LoadData();
        m_Controller.isGameActive = true;
        m_Controller.isCharacterPlaying = m_CharActive;

    }
    public override void ApplyData()
    {

        base.ApplyData();
    }

    private void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }
    private void OnDisable()
    {

        SaveData.OnLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}
