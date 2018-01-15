using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PauseMenuButtonUI : MonoBehaviour
{

    public PauseMenuUIManager m_Manager;
    //BOOL ISACTIVE
    public Button[] LevelSelect;

    private void Start()
    {
        m_Manager = FindObjectOfType<PauseMenuUIManager>();
        m_Manager.GetComponent<PauseMenuUIManager>();

    }

    //ACTIVATE
    //DEACTIVATE


    public void SelectButton()
    {
        m_Manager.eventSystem.SetSelectedGameObject(gameObject);
    }
}
