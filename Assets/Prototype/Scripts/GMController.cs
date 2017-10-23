using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Character;

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

    [HideInInspector] public _CharacterController charController;
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
        charController = player.GetComponent<_CharacterController>();
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
        //FadeOut();
        m_CheckpointManager.LoadAllObj();
        //FadeIn();
    }

    public void DefeatPlayer()
    {
        charController.isDefeated = true;
        StartCoroutine(WaitAndRestart());
    }

    public void RevivePlayer()
    {
        charController.isDefeated = false;
        charController.m_Animator.SetFloat("Forward", 0f);
        //charStateController.TransitionToState(charStateController.gameStartState);
    }

    private IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(deathAnimationTime);
        FadeOut();
        yield return new WaitForSeconds(fadeOutTime);
        RevivePlayer();
        LoadCheckpoint();
        FadeIn();

    }
}


