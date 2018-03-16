using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using Character;
using DG.Tweening;

public class ClimbableIconsActivation : MonoBehaviour
{
    public Transform ClimbableCanvas;
    public Sprite startClimbIconJoystick;
    public Sprite startClimbIconKeyboard;
    //public Sprite endClimbIcon;
    public Collider Top;
    public Collider Bottom;
    public int degrees;

    [HideInInspector] public CharacterStateController controllerBoy;
    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform bottomIcons;
    [HideInInspector] public Transform topIcons;
    [HideInInspector] public Transform activePlayer;

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
    }

    public void SwapIcons(Transform position)
    {
        if (InputManager.instance.GetInputState() == InputManager.InputState.MouseKeyboard)
        {
            position.GetChild(0).GetComponent<Image>().sprite = startClimbIconKeyboard;
            position.GetChild(0).GetComponent<Image>().color = alphaMax;
        }
        else if (InputManager.instance.GetInputState() == InputManager.InputState.Controller)
        {
            position.GetChild(0).GetComponent<Image>().sprite = startClimbIconJoystick;
            position.GetChild(0).GetComponent<Image>().color = alphaMax;
        }
    }

    public void ShowIcon(GameObject player)
    {
        //Boy
        if (GMController.instance.isCharacterPlaying == controllerBoy.thisCharacter)
        {
            activePlayer = player.GetComponent<_CharacterController>().m_Camera;

            if (controllerBoy.currentState.name != "Climbing")
            {
               
                // Start climb from Bottom
                if ( controllerBoy.m_CharacterController.climbCollider.transform == Bottom.transform)
                {
                    if (controllerBoy.m_CharacterController.isClimbDirectionRight)
                    {
                        SwapIcons(bottomIcons);
                        player.GetComponent<_CharacterController>().IconPriority(bottomIcons, degrees);
                        bottomIcons.DOLookAt(activePlayer.position, 0.1f);
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
                    //topIcons.DOLocalRotate(new Vector3(0, 0, 0), 0.1f);
                    player.GetComponent<_CharacterController>().IconPriority(topIcons, degrees);
                    topIcons.DOLookAt(activePlayer.position, 0.1f);
                }
            }
            // End Climb Icon
            else if (controllerBoy.currentState.name == "Climbing" )
            {
                HideIcons(bottomIcons);
               
                if (controllerBoy.m_CharacterController.climbCollider.transform == Top.transform)
                {
                    SwapIcons(topIcons);
                    //topIcons.DOLocalRotate(new Vector3(0, 180, 0), 0.1f);
                    player.GetComponent<_CharacterController>().IconPriority(topIcons, degrees);
                    topIcons.DOLookAt(activePlayer.position, 0.1f);
                }
                else
                {
                    HideIcons(topIcons);
                }
            }
           
        }
    }

   

}
