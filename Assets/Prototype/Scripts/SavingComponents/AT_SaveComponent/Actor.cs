using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class Actor : SerializedMonoBehaviour
{
   [HideInEditorMode][HideInPlayMode]
   [ReadOnly]
    public ActorData data;


    [ReadOnly]
    public string thisObjectName;

    public virtual void Awake()
    {
        thisObjectName = this.gameObject.name;
    }
    public virtual void StoreData()
    {
        data.name = thisObjectName;
        data.pos = this.gameObject.transform.position;

    }
    
    public virtual void LoadData()
    {

        thisObjectName = data.name;
        this.gameObject.transform.position= data.pos;
       
     
    }
    public virtual void ApplyData()
    {
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
