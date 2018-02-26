using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance = null;
    int currentSceneIndex;

	void Awake ()
    {
        //Singleton
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
	
    public void ChangeToLoadScene(int currentScene/*, Image fade, float fadeTime*/)
    {
        //fade.DOFade(255,fadeTime);
        currentSceneIndex = currentScene;
        Debug.Log(currentScene);
        Debug.Log(currentSceneIndex);
        AsyncOperation async = SceneManager.LoadSceneAsync("LoadScene");

        //async.allowSceneActivation = false;

        //if()
        //{
        //    async.allowSceneActivation = true;
        //}
    }

    public IEnumerator ChangeLevel(Animator anim)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(currentSceneIndex + 1);
        async.allowSceneActivation = false;

        while(async.progress < 0.9f)
        {
            Debug.Log("Progress: " + async.progress);
            yield return null;
        }

        anim.speed = 0;

        while(!Input.GetButtonDown("Interact"))
        {
            yield return null;
        }

        async.allowSceneActivation = true;
    }

}
