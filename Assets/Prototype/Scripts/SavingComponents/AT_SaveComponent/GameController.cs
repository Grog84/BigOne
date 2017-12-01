using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;


  [HideMonoScript]
public class GameController :MonoBehaviour {
  

    [BoxGroup("Profile Settings")]
    public AT_Profile Profile;



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
      
        allActor = FindObjectsOfType<Actor>();

        //Inizializzazione livelli nuovi
        Profile.completedLevel = new bool[UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
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
    public  void Save()
    {
        Profile.Save();
        SaveTime(DateTime.Now);
        SaveProfile(profilePath, Profile);
        SaveData.Save(dataPath, SaveData.actorContainer);
        
        Debug.Log("Salvato");
    }
    [HideInEditorMode]
    [Button("Load Check point", ButtonSizes.Medium)]
    public  void Load()
    {
        Profile = LoadProfile(profilePath);
        if(allActor.Length!=0)
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
		StartCoroutine (AsycLoad()); 
    }

	IEnumerator AsycLoad()
	{
		Profile= LoadProfile(profilePath);
		SceneManager.LoadSceneAsync(Profile.LastScene);
		yield return null;
	}

	public  static int getlastScene()
	{

		return lastscene;
	}

    private static void SaveProfile(string path, AT_Profile profile)
    {


        profile.LastScene = SceneManager.GetActiveScene().buildIndex;
        for (int i = 0; i <= profile.LastScene; i++)
        {
            profile.completedLevel[i] = true;
        }

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
