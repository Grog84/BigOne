using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using DG.Tweening;
using Character;

public class CollectablesIconsActivation : MonoBehaviour
{

    public Transform CollectableCanvas;
    public Sprite collectableIconKeyboard;
    public Sprite collectableIconJoyStick;
    public Sprite keyIconKeyboard;
    public Sprite keyIconJoyStick;
    public int degrees;
    

    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform icons;
    [HideInInspector] public Collider trigger;
    [HideInInspector] public Transform activePlayer;

    void Awake()
    {     
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100,100,100,255);

        icons = CollectableCanvas.GetChild(0);
        trigger = GetComponent<Collider>();
    }
	
    public void HideIcons()
    {
        icons.GetChild(0).GetComponent<Image>().color = alphaZero;
        icons.GetChild(0).GetComponent<Image>().sprite = null;     
    }

    public void SwapIcons (CharacterStateController playerState)
    {
        if (gameObject.tag == "Key" && playerState.thisCharacter == CharacterActive.Mother)
        {
            if (InputManager.instance.GetInputState() == InputManager.InputState.MouseKeyboard)
            {
                icons.GetChild(0).GetComponent<Image>().sprite = keyIconKeyboard;
                icons.GetChild(0).GetComponent<Image>().color = alphaMax;
            }
            else if (InputManager.instance.GetInputState() == InputManager.InputState.Controller)
            {
                icons.GetChild(0).GetComponent<Image>().sprite = keyIconJoyStick;
                icons.GetChild(0).GetComponent<Image>().color = alphaMax;
            }
        }
        else if (gameObject.tag != "Key")
        {
            if (InputManager.instance.GetInputState() == InputManager.InputState.MouseKeyboard)
            {
                icons.GetChild(0).GetComponent<Image>().sprite = collectableIconKeyboard;
                icons.GetChild(0).GetComponent<Image>().color = alphaMax;
            }
            else if(InputManager.instance.GetInputState() == InputManager.InputState.Controller)
            {
                icons.GetChild(0).GetComponent<Image>().sprite = collectableIconJoyStick;
                icons.GetChild(0).GetComponent<Image>().color = alphaMax;
            }
        }
    }

    public void ShowIcon(GameObject player)
    {
        CharacterStateController playerState = player.GetComponent<CharacterStateController>();

        if (GMController.instance.isCharacterPlaying == playerState.thisCharacter)
        {
            activePlayer = player.GetComponent<_CharacterController>().m_Camera;
            // Collectable icons 
            if (playerState.m_CharacterController.isInItemArea)
            {
                if (playerState.thisCharacter == CharacterActive.Mother && !playerState.m_CharacterController.isPushDirectionRight || 
                    playerState.thisCharacter == CharacterActive.Boy && !playerState.m_CharacterController.isClimbDirectionRight)
                {
                    if (playerState.m_CharacterController.ItemCollider.transform == trigger.transform)
                    {
                        SwapIcons(playerState);
                        player.GetComponent<_CharacterController>().IconPriority(icons, degrees);
                        icons.DOLookAt(activePlayer.position, 0.1f);
                    }                  
                }
   
            }
            else
            {           
                HideIcons();
            }

           
        }     
       
    }
	
	
}
