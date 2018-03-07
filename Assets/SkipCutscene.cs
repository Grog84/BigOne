using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkipCutscene : MonoBehaviour
{
    public GameObject skip;
    bool loading = false;

    public bool doneLoading = false;
    [HideInInspector] public bool canSkip = false;

    private void Start()
    {
        LoadManager.instance.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadManager.instance.SkipCutscene(gameObject));        
    }

    IEnumerator skipFade()
    {
        yield return new WaitForSeconds(2f);
        skip.SetActive(false);
    }      

    void Update ()
    {
        if (doneLoading)
        {
            if (Input.anyKeyDown)
            {
                if (!skip.activeSelf && !loading)
                {
                    skip.SetActive(true);
                    StartCoroutine(skipFade());
                }

                else if (skip.activeSelf && !loading)
                {
                    LoadManager.instance.PlayFade();
                    loading = true;
                    canSkip = true;
                    Debug.Log("Skip");
                }
            }
        }
	}
}
