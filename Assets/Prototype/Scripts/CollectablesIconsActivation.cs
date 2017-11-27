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
    public Sprite collectable;
    public Sprite interact;
    public int degrees;

    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform icons;
    [HideInInspector] public Collider trigger;


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
        icons.GetChild(1).GetComponent<Image>().color = alphaZero;
        icons.GetChild(1).GetComponent<Image>().sprite = null;
    }

    public void SwapIcons (CharacterStateController playerState)
    {
        if (gameObject.tag == "Key" && playerState.thisCharacter == CharacterActive.Mother)
        {
            icons.GetChild(0).GetComponent<Image>().sprite = collectable;
            icons.GetChild(0).GetComponent<Image>().color = alphaMax;

            icons.GetChild(1).GetComponent<Image>().sprite = interact;
            icons.GetChild(1).GetComponent<Image>().color = alphaMax;
        }
        else if (gameObject.tag != "Key" && playerState.thisCharacter == CharacterActive.Boy)
        {
            icons.GetChild(0).GetComponent<Image>().sprite = collectable;
            icons.GetChild(0).GetComponent<Image>().color = alphaMax;

            icons.GetChild(1).GetComponent<Image>().sprite = collectable;
            icons.GetChild(1).GetComponent<Image>().color = alphaMax;
        }
    }

    public void ShowIcon(GameObject player)
    {
        CharacterStateController playerState = player.GetComponent<CharacterStateController>();

        if (GMController.instance.isCharacterPlaying == playerState.thisCharacter)
        {
            // Collectable icons 
            if (playerState.m_CharacterController.isInKeyArea)
            {
                if (playerState.thisCharacter == CharacterActive.Mother && !playerState.m_CharacterController.isPushDirectionRight || 
                    playerState.thisCharacter == CharacterActive.Boy && !playerState.m_CharacterController.isClimbDirectionRight)
                {
                    if (playerState.m_CharacterController.KeyCollider.transform == trigger.transform)
                    {
                        SwapIcons(playerState);
                        player.GetComponent<_CharacterController>().IconPriority(icons, degrees);

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
