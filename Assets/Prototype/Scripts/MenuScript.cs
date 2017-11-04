using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	public void LoadLastMission()
    {
     
        SceneManager.LoadScene(SaveGame.SaveObjComponent.GetLastScene());

    }
    public void ReturnHomePage()
    {
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnHomePage();
        }
    }
}
