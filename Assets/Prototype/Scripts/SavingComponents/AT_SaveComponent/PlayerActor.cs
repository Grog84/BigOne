using StateMachine;
using UnityEngine;

public class PlayerActor : Actor
{
      
    public override void Awake()
    {
        base.Awake();
    }
    public override void StoreData()
    {
        base.StoreData();
    }

    public override  void LoadData()
    {
        //Check player attivo, 
        //Settarlo a GameStart

        base.LoadData();
        
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
