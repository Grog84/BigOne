﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GMController : MonoBehaviour {

    // Transform of the active player
    public CharacterActive activePlayerAtStart;

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
     public bool isGameActive = false;
     public CharacterActive isCharacterPlaying;
    [HideInInspector] public Image fadeEffect;
    
    [Range(0.5f, 5f)]
    public float fadeInTime = 1f;
    [Range(0.5f, 5f)]
    public float fadeOutTime = 1f;
    [Range(0.5f, 5f)]
    public float deathAnimationTime = 1f;

    public float deathTimer = 0f;

    // Save game references and variables
    [HideInInspector] public CheckPointManager m_CheckpointManager;

    // Character interface used to acces those methods requiring both Character controller and character stte machine controller
    [HideInInspector] public CharacterInterface[] m_CharacterInterfaces;
    [HideInInspector] public Transform[] playerTransform;

    // Main Camera
    [HideInInspector] public CameraScript m_MainCamera;

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
        m_CharacterInterfaces = new CharacterInterface[players.Length];
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
        for (int i = 0; i < allEnemiesTransform.Length; i++)
        {
            allEnemiesTransform[i] = allEnemies[i].transform;
        }

        m_MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        m_MainCamera.SwitchLookAt();

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

}


