﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GMController : MonoBehaviour {

    public Transform playerTransform;

    [HideInInspector] public static GMController instance = null;
    [HideInInspector] public Vector3 lastSeenPlayerPosition = new Vector3(1000f, 1000f, 1000f);
    [HideInInspector] public Vector3 lastHeardPlayerPosition = new Vector3(1000f, 1000f, 1000f);
    [HideInInspector] public bool isFadeScreenVisible = true;
    [HideInInspector] public Transform[] allEnemiesTransform;
    [HideInInspector] public int suspiciousGuards = 0, alarmedGuards = 0;

    [HideInInspector] public bool isGameActive = false;
    [HideInInspector] public CheckPointManager m_CheckpointManager;

    [HideInInspector] public CharacterInt m_CharacterInterface;
    //[HideInInspector] public CharacterStateController charStateController;

    private Image fadeEffect;

    static Vector3 resetPlayerPosition = new Vector3(1000f, 1000f, 1000f);

    [Range(0.5f, 5f)]
    public float fadeInTime = 1f;
    [Range(0.5f, 5f)]
    public float fadeOutTime = 1f;
    [Range(0.5f, 5f)]
    public float deathAnimationTime = 1f;

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

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //m_CharacterInterface = player.GetComponent<CharacterInterface>();
        //charStateController = player.GetComponent<CharacterStateController>();

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        allEnemiesTransform = new Transform[allEnemies.Length];
        for (int i = 0; i < allEnemiesTransform.Length; i++)
        {
            allEnemiesTransform[i] = allEnemies[i].transform;
        }

        fadeEffect = GameObject.Find("FadeEffect").GetComponent<Image>();

    }

    private void Start()
    {
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

    public void ActivateGame()
    {
        isGameActive = true;
    }

    public void DeactivateGame()
    {
        isGameActive = false;
    }

    public bool GetGameStatus()
    {
        return isGameActive;
    }

    public void FadeIn()
    {
        fadeEffect.DOFade(0, fadeInTime);
        StartCoroutine(WaitAndActivate());
        isFadeScreenVisible = false;

    }

    private IEnumerator WaitAndActivate()
    {
        // Wait and Activate
        yield return new WaitForSeconds(fadeInTime);
        ActivateGame();
    }

    public void FadeOut()
    {
        fadeEffect.DOFade(1, fadeInTime);
        StartCoroutine(WaitAndDeactivate());
        isFadeScreenVisible = true;

    }

    private IEnumerator WaitAndDeactivate()
    {
        // Deactivate and wait
        DeactivateGame();
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

    public void DefeatPlayer()
    {
        //m_CharacterInterface.m_CharacterController.isDefeated = true;
        StartCoroutine(WaitAndRestart());
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
        m_CharacterInterface.RevivePlayer();
        LoadCheckpoint();
        FadeIn();

    }
}


