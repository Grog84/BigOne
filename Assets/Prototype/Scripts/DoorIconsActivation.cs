using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using DG.Tweening;

public class DoorIconsActivation : MonoBehaviour
{

    public Transform DoorCanvas;
    public Sprite openDoor;
    public Sprite cantOpenDoor;
    public Sprite interact;
    public Sprite cantInteract;
    public Collider outside;
    public Collider inside;

    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform hasKey;
    [HideInInspector] public Transform frontIcons;
    [HideInInspector] public Transform backIcons;

    void Awake()
    {     
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100,100,100,255);
        hasKey = transform.FindDeepChild("DoorBody");

        frontIcons = DoorCanvas.GetChild(0);
        backIcons = DoorCanvas.GetChild(1);
    }
	
    public void HideIcons(Transform orientation)
    {
        orientation.GetChild(0).GetComponent<Image>().color = alphaZero;
        orientation.GetChild(0).GetComponent<Image>().sprite = null;
        orientation.GetChild(1).GetComponent<Image>().color = alphaZero;
        orientation.GetChild(1).GetComponent<Image>().sprite = null;
    }

    public void SwapIcons(Transform hasKey, Transform orientation, CharacterStateController playerState)
    {
        if (hasKey.GetComponent<Doors>().hasKey && playerState. thisCharacter == CharacterActive.Mother)
        {
            orientation.GetChild(0).GetComponent<Image>().sprite = openDoor;
            orientation.GetChild(0).GetComponent<Image>().color = alphaMax;

            orientation.GetChild(1).GetComponent<Image>().sprite = interact;
            orientation.GetChild(1).GetComponent<Image>().color = alphaMax;
        }
        else
        {
            orientation.GetChild(0).GetComponent<Image>().sprite = cantOpenDoor;
            orientation.GetChild(0).GetComponent<Image>().color = alphaMax;

            orientation.GetChild(1).GetComponent<Image>().sprite = cantInteract;
            orientation.GetChild(1).GetComponent<Image>().color = alphaMax;
        }
    }

    public void ShowIcon(GameObject player)
    {
       CharacterStateController playerState = player.GetComponent<CharacterStateController>();

        if (GMController.instance.isCharacterPlaying == playerState.thisCharacter)
        {
            // Door icons 
            if (playerState.m_CharacterController.isDoorDirectionRight)
            {
      
                    if (playerState.m_CharacterController.doorCollider.transform == outside.transform)
                    {
                        SwapIcons(hasKey,frontIcons,playerState);
                    
                    }
                    else if (playerState.m_CharacterController.doorCollider.transform == inside.transform)
                    {
                        SwapIcons(hasKey,backIcons,playerState);

                    }
   
            }
            else
            {
                HideIcons(frontIcons);
                HideIcons(backIcons);
            }

           
        }     
       
    }
	
	
}
