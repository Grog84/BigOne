using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System;

public class GameController : SerializedMonoBehaviour {


    [ReadOnly]
    public Actor[] allActor;

    [ListDrawerSettings]
    public List<ActorData> allActorData;


    private GameObject objPrefab;
    public static GameObject oPrefab;
    public const string playerPath = "/Prototype/Prefabs/";

    private static string dataPath = string.Empty;

    private void Awake()
    {
        allActorData = SaveData.actorContainer.actors;

        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
        objPrefab = this.gameObject;

        
        oPrefab = objPrefab;
    }

    private void Start()
    {
        allActor = FindObjectsOfType<Actor>();

    }

    public static Actor createActor(string path, Vector3 position, Quaternion rotation)
    {
      
        Actor actor = oPrefab.GetComponent<Actor>();

        return actor;
    }
   

    public static Actor createActor(ActorData data, string path, Vector3 position, Quaternion rotation)
    {

        Actor actor = createActor(path, position, rotation);
        actor.data = data;
        return actor;

    }
    public void Update()
    {
       

    }

    [HideInEditorMode]
    [Button("Save Check point", ButtonSizes.Medium)]
    public void Save()
    {

        SaveData.Save(dataPath, SaveData.actorContainer);
    }
    [HideInEditorMode]
    [Button("Load Check point", ButtonSizes.Medium)]
    public void Load()
    {

        SaveData.Load(dataPath,allActor);
    }
    private void OnApplicationQuit()
    {
        //Save();
    }

}
