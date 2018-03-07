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

    private PlayableDirector playable;

    void Awake ()
    {
        //Singleton
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        playable = GetComponent<PlayableDirector>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopFade();
    }

    public void PlayFade()
    {
        playable.Play();
    }

    public void StopFade()
    {
        Debug.Log("STOPPAH!");
        playable.Stop();
    }

    public void ChangeToLoadScene(int currentScene)
    {
            currentSceneIndex = currentScene;
            sceneToLoad = SM.PlayerProfile.LastScene - 1;
            Debug.Log(currentScene);
            Debug.Log(currentSceneIndex);
            AsyncOperation async = SceneManager.LoadSceneAsync("LoadScene");
            GMController.instance.SetAmbientMusicActive(false);
            GMController.instance.SetBkgMusicActive(false);
    }

    public IEnumerator ChangeLevel()
    {
        AsyncOperation async;

        if (currentSceneIndex == (SceneManager.sceneCountInBuildSettings - 2))
        {
            async = SceneManager.LoadSceneAsync(0);
        }
        else
        {
            async = SceneManager.LoadSceneAsync(currentSceneIndex + 1);
        }     
        yield return null;
    }

    public IEnumerator SkipCutscene( GameObject skipCanvas)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(currentSceneIndex + 1);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            yield return null;
        }


        skipCanvas.GetComponent<SkipCutscene>().doneLoading = true;
        Debug.Log(async.progress); 

        while (!skipCanvas.GetComponent<SkipCutscene>().canSkip)
        {
            yield return null;
        }

        async.allowSceneActivation = true;
       // Debug.Log(async.isDone + " async is done"); 

        while (true)
        {
            if (async.isDone)
            {
                Debug.Log("Async Done");
                StopFade();
                yield break;
            }
            else
            {
                Debug.Log("Async not Done");
                yield return null;
            }
        }

    }

}
