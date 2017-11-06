using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

    public EventSystem m_EventSystem;

    private void Awake()
    {
        m_EventSystem = GetComponent<EventSystem>();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GP_Prototype_Level_01");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LG_LoadGame_test");
    }
}
