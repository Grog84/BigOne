using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using DG.Tweening;
using Character;

public class DoorIconsActivation : MonoBehaviour
{

    public Transform DoorCanvas;
    public Sprite openDoorKeyboard;
    public Sprite openDoorJoyStick;
    public Sprite cantOpenDoor;
    public Collider outside;
    public Collider inside;
    public int degrees;

    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform hasKey;
    [HideInInspector] public Transform frontIcons;
    [HideInInspector] public Transform backIcons;
    [HideInInspector] public Transform activePlayer;

    void Awake()
    {     
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100,100,100,255);
        hasKey = transform.FindDeepChild("DoorBody");

        frontIcons = DoorCanvas.GetChild(0);
        backIcons = DoorCanvas.GetChild(1);
    }
	
    public void HideIcons()
    {
        frontIcons.GetChild(0).GetComponent<Image>().color = alphaZero;
        frontIcons.GetChild(0).GetComponent<Image>().sprite = null;
        
        backIcons.GetChild(0).GetComponent<Image>().color = alphaZero;
        backIcons.GetChild(0).GetComponent<Image>().sprite = null;      
    }

    public void SwapIcons(Transform hasKey, Transform orientation, CharacterStateController playerState)
    {
        if (hasKey.GetComponent<Doors>().hasKey && playerState.thisCharacter == CharacterActive.Mother)
        {
            if (InputManager.instance.GetInputState() == InputManager.InputState.MouseKeyboard)
            {
                orientation.GetChild(0).GetComponent<Image>().sprite = openDoorKeyboard;
                orientation.GetChild(0).GetComponent<Image>().color = alphaMax;
            }
            else if (InputManager.instance.GetInputState() == InputManager.InputState.Controller)
            {
                orientation.GetChild(0).GetComponent<Image>().sprite = openDoorJoyStick;
                orientation.GetChild(0).GetComponent<Image>().color = alphaMax;
            }
        }
        else
        {
            orientation.GetChild(0).GetComponent<Image>().sprite = cantOpenDoor;
            orientation.GetChild(0).GetComponent<Image>().color = alphaMax;
        }
    }

    public void ShowIcon(GameObject player)
    {
        CharacterStateController playerState = player.GetComponent<CharacterStateController>();

        if (GMController.instance.isCharacterPlaying == playerState.thisCharacter)
        {
            activePlayer = player.GetComponent<_CharacterController>().m_Camera;
            // Door icons 
            if (playerState.m_CharacterController.isDoorDirectionRight )
            {
                if (playerState.thisCharacter == CharacterActive.Mother && !playerState.m_CharacterController.isPushDirectionRight || 
                    playerState.thisCharacter == CharacterActive.Boy && !playerState.m_CharacterController.isClimbDirectionRight)
                {
                    if (playerState.m_CharacterController.doorCollider.transform == outside.transform)
                    {
                        SwapIcons(hasKey, frontIcons, playerState);
                        player.GetComponent<_CharacterController>().IconPriority(frontIcons, degrees);
                        frontIcons.DOLookAt(activePlayer.position, 0.1f);

                    }
                    else if (playerState.m_CharacterController.doorCollider.transform == inside.transform)
                    {
                        SwapIcons(hasKey, backIcons, playerState);
                        player.GetComponent<_CharacterController>().IconPriority(backIcons, degrees);
                        backIcons.DOLookAt(activePlayer.position, 0.1f);
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
