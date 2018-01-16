using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using AI;
using Sirenix.OdinInspector;

public enum CameraActive {ThirdPersonCameraScript, FirstPersonCameraScript, LedgeCamera}
public enum DayNight { Day, Night}

public class GMController : MonoBehaviour {

    //Switch Player
    public bool canSwitch = false;

    // Transform of the active player
    public CharacterActive activePlayerAtStart;
    public DayNight isDayOrNight;
    public CameraActive activeCamera;

    // Needed for Singleton pattern 
    [HideInInspector] public static GMController instance = null;

    // Guards perception system variables
    [HideInInspector] public Vector3 lastSeenPlayerPosition = new Vector3(1000f, 1000f, 1000f);
    [HideInInspector] public Vector3 lastHeardPlayerPosition = new Vector3(1000f, 1000f, 1000f);
    [HideInInspector] public Vector3 lastPercievedPlayerPosition = new Vector3(1000f, 1000f, 1000f);
    static Vector3 resetPlayerPosition = new Vector3(1000f, 1000f, 1000f);

    // Counter of alarmed guards
    [HideInInspector] public int curiousGuards = 0, alarmedGuards = 0;

    // Transform of all the agents who could hear or see the player
    [HideInInspector] public Transform[] allEnemiesTransform;
    [HideInInspector] public Guard[] allGuards;

    // Variables used in order to trigger transitions when the game is not active
    [ReadOnly] public bool isGameActive = false;
    [ReadOnly] public CharacterActive isCharacterPlaying;
    [HideInInspector] public Image fadeEffect;
    
    [Range(0.5f, 5f)]
    public float fadeInTime = 1f;
    [Range(0.5f, 5f)]
    public float fadeOutTime = 1f;
    [Range(0.5f, 5f)]
    public float deathAnimationTime = 1f;

    [ReadOnly] public float deathTimer = 0f;

    // Save game references and variables
    //[HideInInspector] public CheckPointManager m_CheckpointManager;
    [HideInInspector] public SaveManager m_SaveManager;

    // Character interface used to acces those methods requiring both Character controller and character stte machine controller
    [HideInInspector] public CharacterInterface[] m_CharacterInterfaces;
    [HideInInspector] public Transform[] playerTransform;

    // Main Camera
    [HideInInspector] public CameraScript[] m_MainCamera;

    [HideInInspector] public GameObject[] players;

    // Music
    [FMODUnity.EventRef]
    public string m_BkgMusicPath;
    FMOD.Studio.EventInstance bkgMusic;

    void Awake() 
    {
        //Singleton
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);

        //m_CheckpointManager = GetComponent<CheckPointManager>();
        
        fadeEffect = GameObject.Find("FadeEffect").GetComponent<Image>();

        isCharacterPlaying = activePlayerAtStart;
        players = GameObject.FindGameObjectsWithTag("Player");
        m_CharacterInterfaces = new CharacterInterface[players.Length];
    }

    private void Start()
    {
        
        playerTransform = new Transform[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].name == "Boy")
            {
                m_CharacterInterfaces[(int)CharacterActive.Boy] = players[i].GetComponent<CharacterInterface>();
                playerTransform[(int)CharacterActive.Boy] = players[i].transform;
            }
            else if (players[i].name == "Mother")
            {
                m_CharacterInterfaces[(int)CharacterActive.Mother] = players[i].GetComponent<CharacterInterface>();
                playerTransform[(int)CharacterActive.Mother] = players[i].transform;
            }
        }

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        allEnemiesTransform = new Transform[allEnemies.Length];
        allGuards = new Guard[allEnemies.Length];
        for (int i = 0; i < allEnemiesTransform.Length; i++)
        {
            allEnemiesTransform[i] = allEnemies[i].transform;
            allGuards[i] = allEnemies[i].GetComponent<Guard>();
        }

        m_MainCamera = new CameraScript[2];
        m_MainCamera[0] = GameObject.Find("ThirdPersonCamera").GetComponent<ThirdPersonCameraScript>();
        m_MainCamera[1] = GameObject.Find("FirstPersonCamera").GetComponent<FirstPersonCameraScript>();
        //m_MainCamera[2] = GameObject.Find("LedgeCamera").GetComponent<LedgeCameraScript>();

        m_SaveManager = FindObjectOfType<SaveManager>();
        SaveCheckpoint();

        bkgMusic = FMODUnity.RuntimeManager.CreateInstance(m_BkgMusicPath);
        bkgMusic.start();
    }

    public void UpdatePlayerPosition()
    {
        
        lastPercievedPlayerPosition = players[(int)isCharacterPlaying].transform.position;
    }

    public void ResetPlayerLastSeenPosition()
    {
        lastSeenPlayerPosition = resetPlayerPosition;
    }

    public void ResetPlayerLastHeardPosition()
    {
        lastHeardPlayerPosition = resetPlayerPosition;
    }

    public void SetActive(bool state)
    {
        isGameActive = state;
    }

    public bool GetGameStatus()
    {
        return isGameActive;
    }

    public void SaveCheckpoint()
    {
        m_SaveManager.Save();
    }

    public void LoadCheckpoint()
    {
        m_SaveManager.Load();
    }

    public IEnumerator WaitDeathAnimation()
    {
        yield return new WaitForSeconds(deathAnimationTime);
    }

    public IEnumerator WaitFadeOut()
    {
        yield return new WaitForSeconds(fadeOutTime);
    }

    public void MoveToNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void MoveToScene(int nextSceneIndex)
    {
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void ResetGuardsBlackBoard()
    {
        foreach (var guard in allGuards)
        {
            guard.SetBlackboardValue("PlayerInSight", false);
        }
    }

    public void SetBkgMusicState(float value)
    {
        SetFMODParameter(bkgMusic, "GuardStatus", value);
    }

    void SetFMODParameter(FMOD.Studio.EventInstance e, string name, float value)
    {
        FMOD.Studio.ParameterInstance parameter;
        FMOD.RESULT getOk = e.getParameter(name, out parameter);
        if (getOk == FMOD.RESULT.ERR_INVALID_PARAM)
        {
            return;
        }
        parameter.setValue(value);
    }

}


