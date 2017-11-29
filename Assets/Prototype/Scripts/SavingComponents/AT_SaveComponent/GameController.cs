using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameController :MonoBehaviour {

    
    [BoxGroup("Out Application Propreties",true,true)]
    public bool SaveOnClose = false;
    [BoxGroup("Out Application Propreties", true, true)]
    public bool LoadOnOpen = false;

    [HideInEditorMode]    [ReadOnly] 
    public Actor[] allActor;

    [HideInEditorMode]    [ReadOnly]    [BoxGroup("Build & Index Stuff (Hidden in Editor Mode)", true, true)]
    public int currentLoadedScene;
    [HideInEditorMode]    [ReadOnly]    [BoxGroup("Build & Index Stuff (Hidden in Editor Mode)", true, true)]    
    public int currentSceneInBuild;
    [HideInEditorMode]    [ReadOnly]    [BoxGroup("Build & Index Stuff (Hidden in Editor Mode)", true, true)]
    public int currentScene;
    [HideInEditorMode]    [ReadOnly]    [BoxGroup("Build & Index Stuff (Hidden in Editor Mode)", true, true)]
    public string currentSceneName;
   

    private List<ActorData> allActorData;


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

        #region Build&Index Stuff's Code
        currentLoadedScene = SceneManager.sceneCount;
        currentSceneInBuild = SceneManager.sceneCountInBuildSettings;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        currentSceneName = SceneManager.GetActiveScene().name;
        
        #endregion
    }
    private void Start()
    {
        allActor = FindObjectsOfType<Actor>();

        if(LoadOnOpen)
        {
            Load();
        }
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
    
    [HideInEditorMode]
    [Button("Save Check point", ButtonSizes.Medium)]
    public  void Save()
    {
        SaveData.Save(dataPath, SaveData.actorContainer);
    }
    [HideInEditorMode]
    [Button("Load Check point", ButtonSizes.Medium)]
    public  void Load()
    {

        SaveData.Load(dataPath,allActor);
    }
    private void OnApplicationQuit()
    {
        if(SaveOnClose)
        {
            Save();
        }
    }

}
