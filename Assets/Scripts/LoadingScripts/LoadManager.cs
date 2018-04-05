using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Playables;

public class LoadManager : MonoBehaviour
{

    [HideInInspector] public static LoadManager instance = null;
    [HideInInspector] public int currentSceneIndex;
    [HideInInspector] public int sceneToLoad;
    [HideInInspector] public SaveManager SM;
    [HideInInspector] public GameObject skipTimeline;

    [HideInInspector] public bool isContinue;
    [HideInInspector] public bool isPreloading;

    [HideInInspector] public bool isSceneSelected;
    [HideInInspector] public bool loadSelected;
    [HideInInspector] public bool returningToMainMenu;

    public Canvas fadeCanvas;
    public float timer;
    private PlayableDirector playable;

    void Awake ()
    {
        //Singleton
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

       // playable = GetComponent<PlayableDirector>();

        if (GameObject.Find("SaveManager") != null)
        {
            SM = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopFade();
    }

    public void PlayFade()
    {
        Debug.Log("Start Fade");
        fadeCanvas.sortingOrder = 1;
        playable.Play();
    }

    public void StopFade()
    {
        // Debug.Log("mannaggia a lorenzo");
        playable = GetComponent<PlayableDirector>();
        playable.Stop();
        fadeCanvas.sortingOrder = -1;
    }

    public void EnableContinue()
    {
        isContinue = true;
    }

    public void ChangeToLoadScene(int currentScene)
    {
         currentSceneIndex = currentScene;
         //sceneToLoad = SM.PlayerProfile.LastScene;
       
        if (!isPreloading)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync("LoadScene");
        }
        else
        {
            skipTimeline.GetComponent<SkipCutscene>().canSkip = true;
           // Debug.Log(" can skip " + skipTimeline.GetComponent<SkipCutscene>().canSkip);
        }

        if (GameObject.Find("GameManager") != null)
        {
            GMController.instance.SetAmbientMusicActive(false);
            GMController.instance.SetBkgMusicActive(false);
        }
    }


    public IEnumerator ChangeLevel()
    {
        AsyncOperation async;
        // If is in the end cutscene
        if (currentSceneIndex == (SceneManager.sceneCountInBuildSettings - 2))
        {
            async = SceneManager.LoadSceneAsync(0);
            async.allowSceneActivation = false;
            yield return new WaitForSeconds(timer);
            async.allowSceneActivation = true;
        }
        // If is continuing the last game session
        //else if(isContinue)
        //{
        //    isContinue = false;
        //    async = SceneManager.LoadSceneAsync(sceneToLoad);
        //}
        // Normal game progression
        else if(isSceneSelected)
        {
            isSceneSelected = false;
            loadSelected = true;
            async = SceneManager.LoadSceneAsync(currentSceneIndex);
            async.allowSceneActivation = false;
            yield return new WaitForSeconds(timer);
            async.allowSceneActivation = true;
        }
        // Returning to Main Menu from Pause
        else if(returningToMainMenu)
        {
            returningToMainMenu = false;
            async = SceneManager.LoadSceneAsync(0);
            async.allowSceneActivation = false;
            yield return new WaitForSeconds(timer);
            async.allowSceneActivation = true;
        }
        else
        {
            async = SceneManager.LoadSceneAsync(currentSceneIndex + 1);
            async.allowSceneActivation = false;
            yield return new WaitForSeconds(timer);
            async.allowSceneActivation = true;
        }     

        yield return null;
    }

    public IEnumerator SkipCutscene(GameObject skipCanvas)
    {
        skipTimeline = skipCanvas;
        isPreloading = true;

        AsyncOperation async = SceneManager.LoadSceneAsync("LoadScene");
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            yield return null;
        }


        skipTimeline.GetComponent<SkipCutscene>().doneLoading = true;

        while (!skipTimeline.GetComponent<SkipCutscene>().canSkip)
        {
            yield return null;
        }

        async.allowSceneActivation = true;
        isPreloading = false;
    }

}
