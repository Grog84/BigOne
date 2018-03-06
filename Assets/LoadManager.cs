using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadManager : MonoBehaviour
{
    [HideInInspector] public static LoadManager instance = null;
    [HideInInspector] public int currentSceneIndex;

	void Awake ()
    {
        //Singleton
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
	
    public void ChangeToLoadScene(int currentScene)
    {
        currentSceneIndex = currentScene;
        Debug.Log(currentScene);
        Debug.Log(currentSceneIndex);
        AsyncOperation async = SceneManager.LoadSceneAsync("LoadScene");
        GMController.instance.SetAmbientMusicActive(false);
        GMController.instance.SetBkgMusicActive(false);
    }

    public IEnumerator ChangeLevel(Animator anim, Text skip)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(currentSceneIndex + 1);
        async.allowSceneActivation = false;

        while(async.progress < 0.9f)
        {
            Debug.Log("Progress: " + async.progress);
            yield return null;
        }

        skip.gameObject.SetActive(true);
        //anim.speed = 0;
        anim.gameObject.SetActive(false);

        while(!Input.anyKeyDown)
        {
            yield return null;
        }

        async.allowSceneActivation = true;
    }

}
