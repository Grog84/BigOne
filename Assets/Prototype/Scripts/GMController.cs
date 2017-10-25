using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GMController : MonoBehaviour {

    // Transform of the active player
    public CharacterActive activePlayerAtStart;
    public Transform[] playerTransform;

    // Needed for Singleton pattern 
    [HideInInspector] public static GMController instance = null;

    // Guards perception system variables
    [HideInInspector] public Vector3 lastSeenPlayerPosition = new Vector3(1000f, 1000f, 1000f);
    [HideInInspector] public Vector3 lastHeardPlayerPosition = new Vector3(1000f, 1000f, 1000f);
    static Vector3 resetPlayerPosition = new Vector3(1000f, 1000f, 1000f);

    // Counter of alarmed guards
    [HideInInspector] public int suspiciousGuards = 0, alarmedGuards = 0;

    // Transform of all the agents who could hear or see the player
    [HideInInspector] public Transform[] allEnemiesTransform;

    // Variables used in order to trigger transitions when the game is not active
    [HideInInspector] public bool isGameActive = false;
    [HideInInspector] public CharacterActive isCharacterPlaying;
    //[HideInInspector] public bool isFadeScreenVisible = true;
    [HideInInspector] public Image fadeEffect;
    
    [Range(0.5f, 5f)]
    public float fadeInTime = 1f;
    [Range(0.5f, 5f)]
    public float fadeOutTime = 1f;
    [Range(0.5f, 5f)]
    public float deathAnimationTime = 1f;

    // Save game references and variables
    [HideInInspector] public CheckPointManager m_CheckpointManager;

    // Character interface used to acces those methods requiring both Character controller and character stte machine controller
    [HideInInspector] public CharacterInt[] m_CharacterInterfaces;

    void Awake() 
    {
        //Singleton
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);

        m_CheckpointManager = GetComponent<CheckPointManager>();
        fadeEffect = GameObject.Find("FadeEffect").GetComponent<Image>();

        isCharacterPlaying = activePlayerAtStart;
    }

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        m_CharacterInterfaces = new CharacterInt[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].name == "Boy")
                m_CharacterInterfaces[(int)CharacterActive.Boy] = players[i].GetComponent<CharacterInt>();
            else if(players[i].name == "Mother")
                m_CharacterInterfaces[(int)CharacterActive.Mother] = players[i].GetComponent<CharacterInt>();
        }

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        allEnemiesTransform = new Transform[allEnemies.Length];
        for (int i = 0; i < allEnemiesTransform.Length; i++)
        {
            allEnemiesTransform[i] = allEnemies[i].transform;
        }

        SaveCheckpoint();
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

    public void FadeIn()
    {
        fadeEffect.DOFade(0, fadeInTime);
        StartCoroutine(WaitAndActivate());
        //isFadeScreenVisible = false;
    }

    private IEnumerator WaitAndActivate()
    {
        // Wait and Activate
        yield return new WaitForSeconds(fadeInTime);
        SetActive(true);
    }

    public void FadeOut()
    {
        fadeEffect.DOFade(1, fadeInTime);
        StartCoroutine(WaitAndDeactivate());
        //isFadeScreenVisible = true;

    }

    private IEnumerator WaitAndDeactivate()
    {
        // Deactivate and wait
        SetActive(false);
        yield return new WaitForSeconds(fadeOutTime);
    }

    public void SaveCheckpoint()
    {
        m_CheckpointManager.SaveAllObj();
    }

    public void LoadCheckpoint()
    {
        m_CheckpointManager.LoadAllObj();
    }

    public IEnumerator WaitDeathAnimation()
    {
        yield return new WaitForSeconds(deathAnimationTime);
    }

    public IEnumerator WaitFadeOut()
    {
        yield return new WaitForSeconds(fadeOutTime);
    }

    public IEnumerator WaitAndRestart()
    {
        yield return StartCoroutine(WaitDeathAnimation());
        FadeOut();
        yield return StartCoroutine(WaitFadeOut());
        m_CharacterInterfaces[(int)isCharacterPlaying].RevivePlayer();
        LoadCheckpoint();
        FadeIn();

    }
}


