﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController :MonoBehaviour {


    [BoxGroup("Profile Settings")]
    public AT_Profile Profile;
    
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
    private static string profilePath = string.Empty;

    private void Awake()
    {
        allActorData = SaveData.actorContainer.actors;
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
        profilePath = System.IO.Path.Combine(Application.persistentDataPath, "Profile.json");
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
       Profile.AC = SaveData.actorContainer;
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

        Profile.AC = SaveData.actorContainer;
        Profile.dateTime = DateTime.Now;
        SaveProfile(profilePath, Profile);
        Debug.Log("Salvato");
    }
    [HideInEditorMode]
    [Button("Load Check point", ButtonSizes.Medium)]
    public  void Load()
    {
        Profile = LoadProfile(profilePath);
        SaveData.Load(dataPath,allActor);
    }
    private void OnApplicationQuit()
    {

       
        SaveProfile(profilePath, Profile);
        if(SaveOnClose)
        {
            Save();
        }
    }

    public void LoadLastScene()
    {
       Profile= LoadProfile(profilePath);
        SceneManager.LoadSceneAsync(Profile.LastScene);
    }

    

    private static void SaveProfile(string path, AT_Profile profile)
    {

        profile.dateTime = DateTime.Now;
        profile.LastScene = SceneManager.GetActiveScene().buildIndex;

        string json = JsonUtility.ToJson(profile);

        StreamWriter sw = File.CreateText(path);
        sw.Close();

        File.WriteAllText(path, json);

    }
    private static AT_Profile LoadProfile(string path)
    {
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<AT_Profile>(json);


    }

}
