using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using Character;

public class ClimbableIconsActivation : MonoBehaviour
{
    public Transform ClimbableCanvas;
    public Sprite startClimbIcon;
    public Sprite interact;
    public Sprite endClimbIcon;
    public Collider Top;
    public Collider Bottom;
    public int degrees;

    [HideInInspector] public CharacterStateController controllerBoy;
    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform bottomIcons;
    [HideInInspector] public Transform topIcons;


    void Awake()
    {
        controllerBoy = GameObject.Find("Boy").GetComponent<CharacterStateController>();
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100, 100, 100, 255); ;

        bottomIcons = ClimbableCanvas.GetChild(0);
        topIcons = ClimbableCanvas.GetChild(1);
    }
	
    public void HideIcons(Transform position)
    {
         
        position.GetChild(0).GetComponent<Image>().color = alphaZero;
        position.GetChild(0).GetComponent<Image>().sprite = null;
    
        position.GetChild(1).GetComponent<Image>().color = alphaZero;
        position.GetChild(1).GetComponent<Image>().sprite = null;

       
    }

    public void SwapIcons(Transform position)
    {
        position.GetChild(0).GetComponent<Image>().sprite = startClimbIcon;
        position.GetChild(0).GetComponent<Image>().color = alphaMax;

        position.GetChild(1).GetComponent<Image>().sprite = interact;
        position.GetChild(1).GetComponent<Image>().color = alphaMax;
    }

    public void ShowIcon(GameObject player)
    {
        //Boy
        if (GMController.instance.isCharacterPlaying == controllerBoy.thisCharacter)
        {            
            if (controllerBoy.currentState.name != "Climbing")
            {
                // Start climb from Bottom
                if ( controllerBoy.m_CharacterController.climbCollider.transform == Bottom.transform)
                {
                    if (controllerBoy.m_CharacterController.isClimbDirectionRight)
                    {
                        SwapIcons(bottomIcons);
                        player.GetComponent<_CharacterController>().IconPriority(bottomIcons, degrees);
                    }
                   else 
                   {
                        HideIcons(bottomIcons);
                   }
                }
                // Start climb from top Icon
                else if (controllerBoy.m_CharacterController.climbCollider.transform == Top.transform)
                {
                    SwapIcons(topIcons);
                    player.GetComponent<_CharacterController>().IconPriority(topIcons, degrees);
                }
            }
            // End Climb Icon
            else if (controllerBoy.currentState.name == "Climbing" )
            {
                HideIcons(bottomIcons);

                if (controllerBoy.m_CharacterController.climbCollider.transform == Top.transform)
                {
                    SwapIcons(topIcons);
                    player.GetComponent<_CharacterController>().IconPriority(topIcons, degrees);
                }
                else
                {
                    HideIcons(topIcons);
                }
            }
           
        }
    }

   

}
