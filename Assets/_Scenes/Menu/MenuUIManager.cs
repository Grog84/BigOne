using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System;

public class MenuUIManager : MonoBehaviour
{

    private SaveManager SM;
    private Canvas m_Canvas;

    bool isMouseActive;

    int State;

    GameObject[] UiButton;
    public Button continueButton;


    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;
    //FMOD.Studio.Bus Master;

    float MusicVolume = 0.5f;
    float SFXVolume = 0.5f;
    //float MasterVolume = 0.5f;
    FMOD.Studio.EventInstance SFXVoumeTestEvent;
    

    private void Awake()
    {
        UiButton = GameObject.FindGameObjectsWithTag("CanvasUI");
        m_Canvas = FindObjectOfType<Canvas>();
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        //Master = FMODUnity.RuntimeManager.GetBus("bus:");
    //    SFXVoumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("");
    }

    private void Start()
    {
        State = 0;
        Time.timeScale = 1;
        SM = FindObjectOfType<SaveManager>();
        ReturnToMainMenu();


        // ContinueButtonOnOff();
    }
    private void Update()
    {
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
        //Master.setVolume(MasterVolume);


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
        if (EventSystem.current.currentSelectedGameObject==null)
        {
            switch(State)
            {
                case 0:
                    GameObject.Find("NewGameButton_Beta").GetComponent<Button>().Select();
                    break;
                case 1:
                    GameObject.Find("CloseSelectLevelMenu").GetComponent<Button>().Select();
                    break;
                case 2:
                    GameObject.Find("ExitUnconfirmed").GetComponent<Button>().Select();
                    break;
                case 3:
                    GameObject.Find("BackMainMenuButton").GetComponent<Button>().Select();
                    break;
                case 4:
                    GameObject.Find("CloseAudioMenu").GetComponent<Button>().Select();
                    break;

                default: break;
            }
        }
    }


    //public void MasterVolumeLevel(float newMasterVolume)
    //{
    //    MasterVolume = newMasterVolume;
    //}

    public void MusicVolumeLevel(float newMusicVolume)
    {

        MusicVolume = newMusicVolume;
        if(MusicVolume==0)
        {
            Music.setMute(true);
        }
        else
        {
            Music.setMute(false);
        }
    }
    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;
        if (SFXVolume == 0)
        {
            SFX.setMute(true);
        }
        else
        {
            SFX.setMute(false);
        }
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
        State = 0;
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
        State = 1;
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
        State = 3;
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
        State = 4;
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
        //SceneManager.LoadSceneAsync(indexValue);
        LoadManager.instance.isSceneSelected = true;
        LoadManager.instance.ChangeToLoadScene(indexValue);

        //Chiamare Singletone


    }

    public void Continue()
    {
        // SM.PlayerProfile.Continue = true;
        HideMouseCursor();
        LoadManager.instance.PlayFade();
        //LoadManager.instance.isContinue = true;
        LoadManager.instance.ChangeToLoadScene(SceneManager.sceneCountInBuildSettings);
        //SM.LoadLastScene();
    }

    int ExitOrNewGame;
    public void StartNewGame()
    {
        Debug.Log("Inizio");
        HideMouseCursor();
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
        State = 2;
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
   
    public void HideMouseCursor()
    {
        Debug.Log("lock");
        Cursor.lockState = CursorLockMode.Locked;
    }

}

