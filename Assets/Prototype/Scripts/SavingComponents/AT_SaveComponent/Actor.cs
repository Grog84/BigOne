using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class Actor : SerializedMonoBehaviour
{

    public ActorData data;// = new ActorData();

    public string objName;

    public virtual void Awake()
    {
        objName = this.gameObject.name;
    }
    public virtual void StoreData()
    {
        data.name = objName;
        data.pos = this.gameObject.transform.position;

    }


    public virtual void LoadData()
    {

        objName = data.name;
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
