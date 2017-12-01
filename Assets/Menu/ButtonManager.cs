using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : Button
{
    private MenuManager m_MenuManager;

    protected override void Awake()
    {
        m_MenuManager = GetComponent<MenuManager>();
    }

    private void OnMouseOver()
    {
        m_MenuManager.m_EventSystem.SetSelectedGameObject(this.gameObject);
    }

}
