using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;

public class ClimbableIconsActivation : MonoBehaviour
{
    public Transform ClimbableCanvas;
    public Sprite startClimbIcon;
    public Sprite interact;
    public Sprite endClimbIcon;
    public Collider Top;
    public Collider Bottom;

    [HideInInspector] public CharacterStateController controllerBoy;
    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;


    void Awake()
    {
        controllerBoy = GameObject.Find("Boy").GetComponent<CharacterStateController>();
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100, 100, 100, 255); ;
    }
	
    public void HideIcons()
    {
         // Reset Icons
         
        ClimbableCanvas.GetChild(0).GetComponent<Image>().color = alphaZero;
        ClimbableCanvas.GetChild(0).GetComponent<Image>().sprite = null;
    
        ClimbableCanvas.GetChild(1).GetComponent<Image>().color = alphaZero;
        ClimbableCanvas.GetChild(1).GetComponent<Image>().sprite = null;

        ClimbableCanvas.GetChild(2).GetComponent<Image>().color = alphaZero;
        ClimbableCanvas.GetChild(2).GetComponent<Image>().sprite = null;

        ClimbableCanvas.GetChild(3).GetComponent<Image>().color = alphaZero;
        ClimbableCanvas.GetChild(3).GetComponent<Image>().sprite = null;

    }

    public void ShowIcon()
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
                        ClimbableCanvas.GetChild(0).GetComponent<Image>().color = alphaMax;
                        ClimbableCanvas.GetChild(0).GetComponent<Image>().sprite = startClimbIcon;

                        ClimbableCanvas.GetChild(2).GetComponent<Image>().color = alphaMax;
                        ClimbableCanvas.GetChild(2).GetComponent<Image>().sprite = interact;
                    }
                   else 
                   {
                        ClimbableCanvas.GetChild(0).GetComponent<Image>().color = alphaZero;
                        ClimbableCanvas.GetChild(0).GetComponent<Image>().sprite = null;

                        ClimbableCanvas.GetChild(2).GetComponent<Image>().color = alphaZero;
                        ClimbableCanvas.GetChild(2).GetComponent<Image>().sprite = null;
                    }
                }
                // Start climb from top Icon
                else if (controllerBoy.m_CharacterController.climbCollider.transform == Top.transform)
                {
                    ClimbableCanvas.GetChild(1).GetComponent<Image>().color = alphaMax;
                    ClimbableCanvas.GetChild(1).GetComponent<Image>().sprite = startClimbIcon;

                    ClimbableCanvas.GetChild(3).GetComponent<Image>().color = alphaMax ;
                    ClimbableCanvas.GetChild(3).GetComponent<Image>().sprite = interact;
                }
            }
            // End Climb Icon
            else if (controllerBoy.currentState.name == "Climbing" )
            {
                ClimbableCanvas.GetChild(0).GetComponent<Image>().color = alphaZero;
                ClimbableCanvas.GetChild(0).GetComponent<Image>().sprite = null;

                ClimbableCanvas.GetChild(2).GetComponent<Image>().color = alphaZero;
                ClimbableCanvas.GetChild(2).GetComponent<Image>().sprite = null;

                if (controllerBoy.m_CharacterController.climbCollider.transform == Top.transform)
                {
                    ClimbableCanvas.GetChild(1).GetComponent<Image>().color = alphaMax;
                    ClimbableCanvas.GetChild(1).GetComponent<Image>().sprite = endClimbIcon;

                    ClimbableCanvas.GetChild(3).GetComponent<Image>().color = alphaMax;
                    ClimbableCanvas.GetChild(3).GetComponent<Image>().sprite = interact;
                }
                else
                {
                    ClimbableCanvas.GetChild(1).GetComponent<Image>().color = alphaZero;
                    ClimbableCanvas.GetChild(1).GetComponent<Image>().sprite = null;

                    ClimbableCanvas.GetChild(3).GetComponent<Image>().color = alphaZero;
                    ClimbableCanvas.GetChild(3).GetComponent<Image>().sprite = null;
                }
            }
           
        }
    }

   

}
