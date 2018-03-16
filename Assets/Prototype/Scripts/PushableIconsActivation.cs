using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using Character;
using DG.Tweening;

public class PushableIconsActivation : MonoBehaviour
{
    public Transform PushableCanvas;
    public Sprite startPushKeyboard;
    public Sprite startPushJoyStick;
    public Collider trigger1;
    public Collider trigger2;
    public Collider trigger3;
    public Collider trigger4;
    public int degrees;

    [HideInInspector] public CharacterStateController controllerMother;
    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform trig1;
    [HideInInspector] public Transform trig2;
    [HideInInspector] public Transform trig3;
    [HideInInspector] public Transform trig4;
    [HideInInspector] public Transform activePlayer;
    [HideInInspector] public bool stopUpdate = true;

    void Awake()
    {
        controllerMother = GameObject.Find("Mother").GetComponent<CharacterStateController>();
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100, 100, 100, 255);

        trig1 = PushableCanvas.GetChild(0);
        trig2 = PushableCanvas.GetChild(1);
        trig3 = PushableCanvas.GetChild(2);
        trig4 = PushableCanvas.GetChild(3);
    }

    public void HideIcons(Transform trigger)
    {
        trigger.GetChild(0).GetComponent<Image>().color = alphaZero;
        trigger.GetChild(0).GetComponent<Image>().sprite = null;  
    }
	
    public void SwapIcons(Transform trigger)
    {
        if (InputManager.instance.GetInputState() == InputManager.InputState.MouseKeyboard)
        {
            trigger.GetChild(0).GetComponent<Image>().sprite = startPushKeyboard;
            trigger.GetChild(0).GetComponent<Image>().color = alphaMax;
        }
        else if (InputManager.instance.GetInputState() == InputManager.InputState.Controller)
        {
            trigger.GetChild(0).GetComponent<Image>().sprite = startPushJoyStick;
            trigger.GetChild(0).GetComponent<Image>().color = alphaMax;
        }
    }

    public void ShowIcon(GameObject player)
    {
        //Mother
        if (GMController.instance.isCharacterPlaying == controllerMother.thisCharacter)
        {
            activePlayer = player.GetComponent<_CharacterController>().m_Camera;
            // Pushable Icons
            if (controllerMother.m_CharacterController.isPushDirectionRight && controllerMother.currentState.name != "Pushing")
            {
                if (controllerMother.m_CharacterController.pushCollider.transform == trigger1.transform)
                {
                    SwapIcons(trig1);
                    player.GetComponent<_CharacterController>().IconPriority(trig1, degrees);
                    trig1.DOLookAt(activePlayer.position, 0.1f);
                    stopUpdate = false;
                }
                else if (controllerMother.m_CharacterController.pushCollider.transform == trigger2.transform)
                {
                    SwapIcons(trig2);
                    player.GetComponent<_CharacterController>().IconPriority(trig2, degrees);
                    trig2.DOLookAt(activePlayer.position, 0.1f);
                    stopUpdate = false;
                }
                else if (controllerMother.m_CharacterController.pushCollider.transform == trigger3.transform)
                {
                    SwapIcons(trig3);
                    player.GetComponent<_CharacterController>().IconPriority(trig3, degrees);
                    trig3.DOLookAt(activePlayer.position, 0.1f);
                    stopUpdate = false;
                }
                else if (controllerMother.m_CharacterController.pushCollider.transform == trigger4.transform)
                {
                    SwapIcons(trig4);
                    player.GetComponent<_CharacterController>().IconPriority(trig4, degrees);
                    trig4.DOLookAt(activePlayer.position, 0.1f);
                    stopUpdate = false;
                }
            }          
           
        }
    }


    private void Update()
    {
        if (controllerMother.m_CharacterController.pushHit != gameObject && !stopUpdate || controllerMother.currentState.name == "Pushing")
        {
            HideIcons(trig1);
            HideIcons(trig2);
            HideIcons(trig3);
            HideIcons(trig4);

            stopUpdate = true;
        }
       
    }

}
