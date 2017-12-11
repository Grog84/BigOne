using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using Character;
using DG.Tweening;

public class CharacterSwitchIconsActivation : MonoBehaviour
{
    public Transform CharacterSwitchCanvas;
    public Sprite switchIcon;
    public Sprite interact;
    public int degrees;

    [HideInInspector] public GameObject controller;
    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform Icons;
    [HideInInspector] public Vector3 newPlayer;

    void Awake()
    {
        controller = GetComponent<CharacterSwitch>().activePlayer;
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100, 100, 100, 255); ;

        Icons = CharacterSwitchCanvas.GetChild(0);
    }

    public void HideIcons()
    {
        Icons.GetChild(0).GetComponent<Image>().color = alphaZero;
        Icons.GetChild(0).GetComponent<Image>().sprite = null;

        Icons.GetChild(1).GetComponent<Image>().sprite = null;
        Icons.GetChild(1).GetComponent<Image>().color = alphaZero;
    }

    public void SwapIcons()
    {
        Icons.GetChild(0).GetComponent<Image>().sprite = switchIcon;
        Icons.GetChild(0).GetComponent<Image>().color = alphaMax;

        Icons.GetChild(1).GetComponent<Image>().sprite = interact;
        Icons.GetChild(1).GetComponent<Image>().color = alphaMax;
    }

    public void ShowIcon(GameObject player)
    {
        Transform activePlayer = player.GetComponent<_CharacterController>().m_Camera;
        SwapIcons();
        newPlayer = new Vector3(activePlayer.position.x, Icons.position.y, activePlayer.position.z);
        Icons.DOLookAt(newPlayer, 0.1f);
        player.GetComponent<_CharacterController>().IconPriority(Icons, degrees);           
    }



}
