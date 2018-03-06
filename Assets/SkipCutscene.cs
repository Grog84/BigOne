using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkipCutscene : MonoBehaviour
{
    public GameObject skip;
    bool loading = false;

    IEnumerator skipFade()
    {
        yield return new WaitForSeconds(2f);
        skip.SetActive(false);
    }      

    void Update ()
    {
		if(Input.anyKeyDown)
        {
            if (!skip.activeSelf)
            {
                skip.SetActive(true);
                StartCoroutine(skipFade());
            }

            else if(skip.activeSelf && !loading)
            {
                loading = true;
                LoadManager.instance.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                Debug.Log("Skip");
                StartCoroutine(LoadManager.instance.ChangeLevel());
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
	}
}
