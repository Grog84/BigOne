using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {

    [HideInInspector] public bool SaveOnClose = true;

    private SaveObjComponent[] saveObjects;

    // Use this for initialization
    void Awake()
    {
        saveObjects = FindObjectsOfType<SaveObjComponent>();   
    }

    // Update is called once per frame

    public void SaveAllObj()
    {
        foreach (SaveObjComponent obj in saveObjects)
        {
            obj.SaveData();
        }
    }

    public void LoadAllObj()
    {
        foreach (SaveObjComponent obj in saveObjects)
        {
            obj.LoadData();
        }
    }
}
