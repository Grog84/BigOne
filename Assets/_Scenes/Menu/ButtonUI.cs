using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour {

    public MenuUIManager m_Manager;

    public void SelectButton()
    {
        m_Manager.eventSystem.SetSelectedGameObject(gameObject);
    }
}
