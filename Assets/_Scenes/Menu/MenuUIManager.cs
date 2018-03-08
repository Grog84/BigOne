using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class MenuUIManager : MonoBehaviour
{

    private SaveManager SM;
    private Canvas m_Canvas;

    bool isMouseActive;

    GameObject[] UiButton;
    public Button continueButton;

    private void Awake()
    {
        UiButton = GameObject.FindGameObjectsWithTag("CanvasUI");
        m_Canvas = FindObjectOfType<Canvas>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        SM = FindObjectOfType<SaveManager>();
        ReturnToMainMenu();

        ContinueButtonOnOff();
    }

    public void ReturnToMainMenu()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyMainMenu")
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    public void OpenLevelSelect()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptySelectLevelMenu")
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    public void CloseLevelSelect()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptySelectLevelMenu")
            {
                a.SetActive(false);
            }

        }
        ReturnToMainMenu();
    }

    public void OpenSettings()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptySettingsMenu")
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    public void CloseSettings()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptySettingsMenu")
            {
                a.SetActive(false);
            }
            ReturnToMainMenu();
        }
    }

    public void OpenAudioSettings()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyAudioMenu")
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    public void CloseAudioSettings()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyAudioMenu")
            {
                a.SetActive(false);

            }
            OpenSettings();
        }
    }

    public void OpenVideoSettings()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyVideoMenu")
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    public void CloseVideoSettings()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyVideoMenu")
            {
                a.SetActive(false);

            }
            OpenSettings();
        }
    }

    public void OpenControllerMenu()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyControllerMenu")
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    public void CloseControllerMenu()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyControllerMenu")
            {
                a.SetActive(false);
            }
            OpenSettings();
        }
    }

    public void LoadLevel(int indexValue)
    {
        SceneManager.LoadSceneAsync(indexValue);
    }

    public void Continue()
    {
        // SM.PlayerProfile.Continue = true;
        LoadManager.instance.PlayFade();
        LoadManager.instance.isContinue = true;
        LoadManager.instance.ChangeToLoadScene(SceneManager.sceneCountInBuildSettings);
        //SM.LoadLastScene();
    }

    int ExitOrNewGame;
    public void StartNewGame()
    {
        SM.PlayerProfile.Continue = false;
        LoadManager.instance.PlayFade();
        SceneManager.LoadSceneAsync(1);

    }
    public void OverwriteProgress()
    {
        SceneManager.LoadSceneAsync(1);

    }
    public void EnableExitPanel()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyExitMenu")
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Negate()
    {
        foreach (GameObject a in UiButton)
        {
            if (a.name == "EmptyAreYouSureMenu" || a.name == "EmptyExitMenu")
            {
                a.SetActive(false);
            }
            ReturnToMainMenu();
        }

    }

    void ContinueButtonOnOff()
    {
        if (File.Exists(SaveManager.dataPath))
        {
            continueButton.interactable = true;
            foreach (GameObject a in UiButton)
            {
                if (a.name == "EmptyMainMenu")
                {
                    a.transform.GetChild(0).gameObject.SetActive(true);
                }            
            }
        }
        else
        {
            continueButton.interactable = false;
            foreach (GameObject a in UiButton)
            {
                if (a.name == "EmptyMainMenu")
                {
                    a.transform.GetChild(0).gameObject.SetActive(false);
                }
                
            }
        }

    }


    private void Update()
    {
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
}