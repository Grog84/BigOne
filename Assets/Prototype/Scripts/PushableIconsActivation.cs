using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;

public class PushableIconsActivation : MonoBehaviour
{
    public Transform PushableCanvas;
    public Sprite startPush;
    public Collider trigger1;
    public Collider trigger2;
    public Collider trigger3;
    public Collider trigger4;

    [HideInInspector] public CharacterStateController controllerMother;
    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;

    [HideInInspector] public bool stopUpdate = true;

    void Awake()
    {
        controllerMother = GameObject.Find("Mother").GetComponent<CharacterStateController>();
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100, 100, 100, 255);
    }
	
    public void ShowIcon()
    {
        //Mother
        if (GMController.instance.isCharacterPlaying == controllerMother.thisCharacter)
        {

            // Pushable Icons
            if (controllerMother.m_CharacterController.isPushDirectionRight && controllerMother.currentState.name != "Pushing")
            {
                if (controllerMother.m_CharacterController.pushCollider.transform == trigger1.transform)
                {
                    PushableCanvas.GetChild(0).GetComponent<Image>().color = alphaMax;
                    PushableCanvas.GetChild(0).GetComponent<Image>().sprite = startPush;
                    stopUpdate = false;
                }
                else if (controllerMother.m_CharacterController.pushCollider.transform == trigger2.transform)
                {
                    PushableCanvas.GetChild(1).GetComponent<Image>().color = alphaMax;
                    PushableCanvas.GetChild(1).GetComponent<Image>().sprite = startPush;
                    stopUpdate = false;
                }
                else if (controllerMother.m_CharacterController.pushCollider.transform == trigger3.transform)
                {
                    PushableCanvas.GetChild(2).GetComponent<Image>().color = alphaMax;
                    PushableCanvas.GetChild(2).GetComponent<Image>().sprite = startPush;
                    stopUpdate = false;
                }
                else if (controllerMother.m_CharacterController.pushCollider.transform == trigger4.transform)
                {
                    PushableCanvas.GetChild(3).GetComponent<Image>().color = alphaMax;
                    PushableCanvas.GetChild(3).GetComponent<Image>().sprite = startPush;
                    stopUpdate = false;
                }
            }          
           
        }
    }

    private void Update()
    {
        if (controllerMother.m_CharacterController.pushHit != gameObject && !stopUpdate || controllerMother.currentState.name == "Pushing")
        {
            PushableCanvas.GetChild(0).GetComponent<Image>().color = alphaZero;
            PushableCanvas.GetChild(0).GetComponent<Image>().sprite = null;


            PushableCanvas.GetChild(1).GetComponent<Image>().color = alphaZero;
            PushableCanvas.GetChild(1).GetComponent<Image>().sprite = null;


            PushableCanvas.GetChild(2).GetComponent<Image>().color = alphaZero;
            PushableCanvas.GetChild(2).GetComponent<Image>().sprite = null;



            PushableCanvas.GetChild(3).GetComponent<Image>().color = alphaZero;
            PushableCanvas.GetChild(3).GetComponent<Image>().sprite = null;

            stopUpdate = true;
        }
       
    }

}
