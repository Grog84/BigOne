using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using QuestManager;


  [HideMonoScript]
public class SaveManager :MonoBehaviour {
  
  //  [ReadOnly]
    [BoxGroup("Profile Settings")]
    public Profile Profile;



	public static int lastscene;
    
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
		lastscene = Profile.LastScene;
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

        Profile = Profile.LoadProfile(profilePath);
        allActor = FindObjectsOfType<Actor>();

        //Inizializzazione livelli nuovi
        Profile.completedLevel = new bool[UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1];
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings-1; i++)
        {
            Profile.completedLevel[i] = false;
        }

        //Caricamento on Open [continue]
        if (LoadOnOpen)
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
    public void Save()
    {
        Profile.Save();
        SaveTime(DateTime.Now);
        Profile.SaveProfile(profilePath, Profile);
        SaveData.Save(dataPath, SaveData.actorContainer);
    }
    [HideInEditorMode]
    [Button("Load Check point", ButtonSizes.Medium)]
    public  void Load()
    {
        Profile = Profile.LoadProfile(profilePath);
        if (allActor.Length != 0)
            SaveData.Load(dataPath, allActor);

    }
    private void OnApplicationQuit()
    {
        Profile.SaveProfile(profilePath, Profile);
        if(SaveOnClose)
        {
            Save();
        }
    }

    public void LoadLastScene()
    {
		StartCoroutine (AsycLoad()); 
    }

	IEnumerator AsycLoad()
	{
		Profile= Profile.LoadProfile(profilePath);
		SceneManager.LoadSceneAsync(Profile.LastScene);
		yield return null;
	}

	public  static int getlastScene()
	{

		return lastscene;
	}

   

    public  void SaveTime(DateTime dateTimeNow)
    {
        Profile.dateTime.day = dateTimeNow.Day;
        Profile.dateTime.minute = dateTimeNow.Minute;
        Profile.dateTime.second = dateTimeNow.Second;
        Profile.dateTime.hour = dateTimeNow.Hour;
        Profile.dateTime.month = dateTimeNow.Month;
        Profile.dateTime.year = dateTimeNow.Year;


    }

}
