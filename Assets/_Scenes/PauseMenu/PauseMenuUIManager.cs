using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

// public class PauseMenuUIManager : MonoBehaviour
public class PauseMenuUIManager : MonoBehaviour

{

    public GameObject[] PauseMenuCanvas;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
    }
    public void Awake()
    {
        PauseMenuCanvas = GameObject.FindGameObjectsWithTag("Pause Menu");
        CloseMenu();
    }

    public void CloseMenu()
    {
        foreach (GameObject a in PauseMenuCanvas)
        {
            if (a.name == "PauseMenuPanel")
            {
                a.SetActive(false);
            }
        }
    }

    public void Pause()
    {

        foreach (GameObject a in PauseMenuCanvas)
        {
            if (a.name == "PauseMenuPanel")
            {
                if (!a.gameObject.activeSelf)
                {
                    a.gameObject.SetActive(true);
                    GMController.instance.isGameActive = false;
                    Time.timeScale = 0;
                    OpenDiary();
                }
                else
                {
                    BackToGame();
                }
            }
        }
    }


    public void BackToGame() // Back to game function
    {
        Time.timeScale = 1;
        GMController.instance.isGameActive = true;

        foreach (GameObject a in PauseMenuCanvas)
        {
            if (a.name == "PauseMenuPanel")
            {
                a.gameObject.SetActive(false);

            }
        }
    }
    public void OpenDiary()
    {
        foreach (GameObject a in PauseMenuCanvas)
        {
            if (a.name == "pause_Quest")
            {
                a.gameObject.SetActive(true);

            }
            else if (a.name == "ControlsImage" || a.name == "MenuAreYouSure")
            {
                a.gameObject.SetActive(false);
            }
        }

    }

    public void Controls() // Show the controls image
    {
        foreach (GameObject a in PauseMenuCanvas)
        {
            if (a.name == "ControlsImage")
            {
                a.gameObject.SetActive(true);

            }
            else if (a.name == "pause_Quest" || a.name == "MenuAreYouSure")
            {
                a.gameObject.SetActive(false);
            }
        }
    }

    public void FadesPauseMenu(string pauseMenuType) // Set the time to wait until the fade animation is finished
    {
        Invoke(pauseMenuType, 0.2f); // Enable the Fade 
    }



    public void BackToMainMenuChoice()// Enable the choice to go the Main Menu
    {
        foreach (GameObject a in PauseMenuCanvas)
        {
            if (a.name == "MenuAreYouSure")
            {
                a.gameObject.SetActive(true);
                a.gameObject.transform.GetChild(0).GetComponent<Button>().Select();

            }
            else if (a.name == "pause_Quest" || a.name == "ControlsImage")
            {
                a.gameObject.SetActive(false);
            }
        }
    }

    public void BackToMainMenuNO()// Close the choice to go the Main Menu
    {
        OpenDiary();
    }

    public void BackToMainMenuYes()// Go to the Main Menu
    {
        ReturnToMainMenu();
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
