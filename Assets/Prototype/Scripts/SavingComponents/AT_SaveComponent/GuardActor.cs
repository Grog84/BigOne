using UnityEngine;
using StateMachine;
using AI;

public class GuardActor : Actor
{
    Guard m_Guard;
    int wayPoint = 0;

    public override void Awake()
    {
        base.Awake();
        m_Guard = GetComponent<Guard>();
    }
    public override void StoreData()
    {
        base.StoreData();
        //wayPoint = m_Guard.GetBlackboardIntValue("CurrentNavPoint");
    }


    public override void LoadData()
    {
        base.LoadData();

        m_Guard.ResetForReload(wayPoint);
    }
    public override void ApplyData()
    {
        //data.activeState = data.m_Controller.saveState;
        SaveData.addActorData(data);
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
