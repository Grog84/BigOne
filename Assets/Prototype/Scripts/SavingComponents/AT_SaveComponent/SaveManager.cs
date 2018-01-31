using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using QuestManager;



public class SaveManager :MonoBehaviour {

    //  [ReadOnly]
    [BoxGroup("Profile Settings")]
    public Profile PlayerProfile;
    //public static int lastscene;

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
        //Caricamento attori (Dati salvati sul disco)

       
        allActor = FindObjectsOfType<Actor>();

        //Inizializzazione livelli nuovi
        PlayerProfile.completedLevel = new bool[UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings-1];
        for (int i = 0; i < PlayerProfile.completedLevel.Length; i++)
        {
            PlayerProfile.completedLevel[i] = false;
        }
        if (PlayerProfile.SavedScene == SceneManager.GetActiveScene().name)
        {
            //Caricamento on Open [continue]
            if (LoadOnOpen)
            {
                Load();
            }

            if (PlayerProfile.Continue == true)
            {
                Load();
            }
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
    public void Save()
    {
        PlayerProfile.Save();
        //SaveTime(DateTime.Now);
        Profile.SaveProfile(profilePath, PlayerProfile);
        SaveData.Save(dataPath, SaveData.actorContainer);
     
    }
    [HideInEditorMode]
    [Button("Load Check point", ButtonSizes.Medium)]
    public  void Load()
    {
        if (PlayerProfile.SavedScene == SceneManager.GetActiveScene().name)
        {
            if (allActor.Length != 0)
                SaveData.Load(dataPath, allActor);
            //GMController.instance.isGameActive = true;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerProfile.Continue = false;
        Profile.SaveProfile(profilePath, PlayerProfile);
        if (SaveOnClose)
        {
           
            
            Save();
        }
    }

    public void LoadLastScene()
    {
		
       // PlayerProfile.Continue = Profile.LoadProfile(profilePath).Continue;
        SceneManager.LoadScene(PlayerProfile.LastScene);
    }
    
    [BoxGroup("Out Application Propreties", true, true)]
    [Button("Clear Save File", ButtonSizes.Gigantic)]
    [ExecuteInEditMode]
    public void ClearSave()
    {
        File.WriteAllText(System.IO.Path.Combine(Application.persistentDataPath, "actors.json"), string.Empty);
        Debug.Log("All Data Cleared");
    }

}
