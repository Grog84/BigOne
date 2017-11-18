using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using DG.Tweening;

public class DoorIconsActivation : MonoBehaviour
{

    public GameObject camera;
    public Transform DoorCanvas;
    public Sprite openDoor;
    public Sprite cantOpenDoor;
    public Sprite interact;
    public Sprite cantInteract;
    public Collider outside;
    public Collider inside;

    [HideInInspector] public CharacterStateController controllerMother;
    [HideInInspector] public CharacterStateController controllerBoy;
    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform hasKey;
    [HideInInspector] public Transform frontIcons;
    [HideInInspector] public Transform backIcons;

    void Awake()
    {
        controllerMother = GameObject.Find("Mother").GetComponent<CharacterStateController>();
        controllerBoy = GameObject.Find("Boy").GetComponent<CharacterStateController>();
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100,100,100,255);
        hasKey = transform.FindDeepChild("DoorBody");

        frontIcons = DoorCanvas.transform.GetChild(0);
        backIcons = DoorCanvas.transform.GetChild(1);
    }
	
    public void HideIcon()
    {
        frontIcons.GetChild(0).GetComponent<Image>().color = alphaZero;
        frontIcons.GetChild(0).GetComponent<Image>().sprite = null;
        frontIcons.GetChild(1).GetComponent<Image>().color = alphaZero;
        frontIcons.GetChild(1).GetComponent<Image>().sprite = null;

        backIcons.GetChild(0).GetComponent<Image>().color = alphaZero;
        backIcons.GetChild(0).GetComponent<Image>().sprite = null;
        backIcons.GetChild(1).GetComponent<Image>().color = alphaZero;
        backIcons.GetChild(1).GetComponent<Image>().sprite = null;
    }

    public void ShowIcon()
    {
        //Mother
        if (GMController.instance.isCharacterPlaying == controllerMother.thisCharacter)
        {
            // Door icons 
            if (controllerMother.m_CharacterController.isDoorDirectionRight && !controllerMother.m_CharacterController.isPushDirectionRight)
            {
                if (hasKey.GetComponent<Doors>().hasKey)
                {
                    if (controllerMother.m_CharacterController.doorCollider.transform == outside.transform)
                    {
                        frontIcons.GetChild(0).GetComponent<Image>().sprite = openDoor;
                        frontIcons.GetChild(0).GetComponent<Image>().color = alphaMax;

                        frontIcons.GetChild(1).GetComponent<Image>().sprite = interact;
                        frontIcons.GetChild(1).GetComponent<Image>().color = alphaMax;
                    
                        frontIcons.DOLookAt(camera.transform.position, 0.1f);
                    }
                    else if (controllerMother.m_CharacterController.doorCollider.transform == inside.transform)
                    {
                        backIcons.GetChild(0).GetComponent<Image>().sprite = openDoor;
                        backIcons.GetChild(0).GetComponent<Image>().color = alphaMax;

                        backIcons.GetChild(1).GetComponent<Image>().sprite = interact;
                        backIcons.GetChild(1).GetComponent<Image>().color = alphaMax;

                        backIcons.DOLookAt(camera.transform.position, 0.1f);
                    }
                }
                else
                {
                    if (controllerMother.m_CharacterController.doorCollider.transform == outside.transform)
                    {
                        frontIcons.GetChild(0).GetComponent<Image>().sprite = cantOpenDoor;
                        frontIcons.GetChild(0).GetComponent<Image>().color = alphaMax;

                        frontIcons.GetChild(1).GetComponent<Image>().sprite = cantInteract;
                        frontIcons.GetChild(1).GetComponent<Image>().color = alphaMax;

                        frontIcons.DOLookAt(camera.transform.position, 0.1f);
                    }
                    else if (controllerMother.m_CharacterController.doorCollider.transform == inside.transform)
                    {
                        backIcons.GetChild(0).GetComponent<Image>().sprite = cantOpenDoor;
                        backIcons.GetChild(0).GetComponent<Image>().color = alphaMax;

                        backIcons.GetChild(1).GetComponent<Image>().sprite = cantInteract;
                        backIcons.GetChild(1).GetComponent<Image>().color = alphaMax;

                        backIcons.DOLookAt(camera.transform.position, 0.1f);
                    }
                }
            }
            else
            {
                HideIcon();
            }

           
        }
        // Boy
        else if (GMController.instance.isCharacterPlaying == controllerBoy.thisCharacter)
        {
            // Door icons 
            if (controllerBoy.m_CharacterController.isDoorDirectionRight && !controllerBoy.m_CharacterController.isClimbDirectionRight)
            {
                if (controllerBoy.m_CharacterController.doorCollider.transform == outside.transform)
                {
                    frontIcons.GetChild(0).GetComponent<Image>().sprite = cantOpenDoor;
                    frontIcons.GetChild(0).GetComponent<Image>().color = alphaMax;

                    frontIcons.GetChild(1).GetComponent<Image>().sprite = cantInteract;
                    frontIcons.GetChild(1).GetComponent<Image>().color = alphaMax;

                    frontIcons.DOLookAt(camera.transform.position, 0.1f);
                }
                else if (controllerBoy.m_CharacterController.doorCollider.transform == inside.transform) 
                {
                    backIcons.GetChild(0).GetComponent<Image>().sprite = cantOpenDoor;
                    backIcons.GetChild(0).GetComponent<Image>().color = alphaMax;

                    backIcons.GetChild(1).GetComponent<Image>().sprite = cantInteract;
                    backIcons.GetChild(1).GetComponent<Image>().color = alphaMax;

                    backIcons.DOLookAt(camera.transform.position, 0.1f);
                }
            }
            else
            {
                HideIcon();
            }
        }
       
    }
	
	
}
