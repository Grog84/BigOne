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
    PauseCamera pauseCamera;
    public GameObject[] PauseMenuCanvas;
    public EventSystem m_EventSystem;
    bool isMouseActive;
    public Canvas m_Canvas;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }

        if (isMouseActive && Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
        {
            isMouseActive = false;
            m_Canvas.GetComponent<GraphicRaycaster>().enabled = false;
        }
        else if (!isMouseActive && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            isMouseActive = true;
            m_Canvas.GetComponent<GraphicRaycaster>().enabled = true;
        }

    }

    public void Awake()
    {
        pauseCamera = FindObjectOfType<PauseCamera>();
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
        //GMController.instance.isGameActive = true;
      

        foreach (GameObject a in PauseMenuCanvas)
        {
            if (a.name == "PauseMenuPanel")
            {
                a.gameObject.SetActive(false);

            }
        }

        m_EventSystem.SetSelectedGameObject(null);
    }
    public void OpenDiary()
    {
        m_EventSystem.SetSelectedGameObject(null);

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

        m_EventSystem.SetSelectedGameObject(m_EventSystem.firstSelectedGameObject);
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
        SceneManager.LoadScene("Menu");
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
