using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AT_LoadSceneASync : MonoBehaviour {

 
    public void StartLoad()
    {
        StartCoroutine(AsynchronousLoad("GP_Prototype_Level_01"));
        TextBox.text = "Caricamento in corso";
        StartCoroutine(LoadingText());
    }
    public RectTransform me;
    public void PressMe()
    {
   
        me.position = new Vector3(Random.Range(0f, 410.0f), Random.Range(0f, 150.0f));

    }

    public Text TextBox;
    IEnumerator LoadingText()
    {
        while (!ao.isDone)
        {

            switch (TextBox.text)
            {
                case "Caricamento in corso":
                    TextBox.text = "Caricamento in corso.";
                    yield return new WaitForSecondsRealtime(00.5f) ;
                    break;
                case "Caricamento in corso.":
                    TextBox.text = "Caricamento in corso..";
                    yield return new WaitForSecondsRealtime(00.5f);
                    break;
                case "Caricamento in corso..":
                    TextBox.text = "Caricamento in corso...";
                    yield return new WaitForSecondsRealtime(00.5f) ;
                    break;
                case "Caricamento in corso...":
                    TextBox.text = "Caricamento in corso";
                    yield return new WaitForSecondsRealtime(00.5f);
                    break;

            }
        }
        yield return null;

    }
    AsyncOperation ao;
IEnumerator AsynchronousLoad(string scene)
    {
     //   yield return null;

      ao= SceneManager.LoadSceneAsync(scene,LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            Debug.Log("State: " + ao.isDone + " Allowed: " + ao.allowSceneActivation);
            // Loading completed
            if (ao.progress == 0.9f)
            {            
                    ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
