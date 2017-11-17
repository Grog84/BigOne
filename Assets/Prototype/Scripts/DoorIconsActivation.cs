using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using DG.Tweening;

public class DoorIconsActivation : MonoBehaviour {

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
    public Transform hasKey;
    void Awake()
    {
        controllerMother = GameObject.Find("Mother").GetComponent<CharacterStateController>();
        controllerBoy = GameObject.Find("Boy").GetComponent<CharacterStateController>();
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100,100,100,255);
        hasKey = transform.FindDeepChild("DoorBody");
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
                        DoorCanvas.GetChild(0).GetComponent<Image>().sprite = openDoor;
                        DoorCanvas.GetChild(0).GetComponent<Image>().color = alphaMax;

                        DoorCanvas.GetChild(2).GetComponent<Image>().color = alphaMax;
                        DoorCanvas.GetChild(2).GetComponent<Image>().sprite = interact;
                    
                        DoorCanvas.DOLookAt(camera.transform.position, 0.1f);
                    }
                    else if (controllerMother.m_CharacterController.doorCollider.transform == inside.transform)
                    {
                        DoorCanvas.GetChild(1).GetComponent<Image>().sprite = openDoor;
                        DoorCanvas.GetChild(1).GetComponent<Image>().color = alphaMax;

                        DoorCanvas.GetChild(3).GetComponent<Image>().color = alphaMax;
                        DoorCanvas.GetChild(3).GetComponent<Image>().sprite = interact;

                        DoorCanvas.DOLookAt(camera.transform.position, 0.1f);
                    }
                }
                else
                {
                    if (controllerMother.m_CharacterController.doorCollider.transform == outside.transform)
                    {
                        DoorCanvas.GetChild(0).GetComponent<Image>().sprite = cantOpenDoor;
                        DoorCanvas.GetChild(0).GetComponent<Image>().color = alphaMax;

                        DoorCanvas.GetChild(2).GetComponent<Image>().color = alphaMax;
                        DoorCanvas.GetChild(2).GetComponent<Image>().sprite = cantInteract;

                        DoorCanvas.DOLookAt(camera.transform.position, 0.1f);
                    }
                    else if (controllerMother.m_CharacterController.doorCollider.transform == inside.transform)
                    {
                        DoorCanvas.GetChild(1).GetComponent<Image>().sprite = cantOpenDoor;
                        DoorCanvas.GetChild(1).GetComponent<Image>().color = alphaMax;

                        DoorCanvas.GetChild(3).GetComponent<Image>().color = alphaMax;
                        DoorCanvas.GetChild(3).GetComponent<Image>().sprite = cantInteract;

                        DoorCanvas.DOLookAt(camera.transform.position, 0.1f);
                    }
                }
            }
            else
            {
                DoorCanvas.GetChild(0).GetComponent<Image>().color = alphaZero;
                DoorCanvas.GetChild(0).GetComponent<Image>().sprite = null;
                DoorCanvas.GetChild(1).GetComponent<Image>().color = alphaZero;
                DoorCanvas.GetChild(1).GetComponent<Image>().sprite = null;
                DoorCanvas.GetChild(2).GetComponent<Image>().color = alphaZero;
                DoorCanvas.GetChild(2).GetComponent<Image>().sprite = null;
                DoorCanvas.GetChild(3).GetComponent<Image>().color = alphaZero;
                DoorCanvas.GetChild(3).GetComponent<Image>().sprite = null;
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
                    DoorCanvas.GetChild(0).GetComponent<Image>().sprite = cantOpenDoor;
                    DoorCanvas.GetChild(0).GetComponent<Image>().color = alphaMax;

                    DoorCanvas.GetChild(2).GetComponent<Image>().sprite = cantInteract;
                    DoorCanvas.GetChild(2).GetComponent<Image>().color = alphaMax;

                    DoorCanvas.DOLookAt(camera.transform.position, 0.1f);
                }
                else if (controllerBoy.m_CharacterController.doorCollider.transform == inside.transform) 
                {
                    DoorCanvas.GetChild(1).GetComponent<Image>().sprite = cantOpenDoor;
                    DoorCanvas.GetChild(1).GetComponent<Image>().color = alphaMax;

                    DoorCanvas.GetChild(3).GetComponent<Image>().sprite = cantInteract;
                    DoorCanvas.GetChild(3).GetComponent<Image>().color = alphaMax;

                    DoorCanvas.DOLookAt(camera.transform.position, 0.1f);
                }
            }
            else
            {
                DoorCanvas.GetChild(0).GetComponent<Image>().color = alphaZero;
                DoorCanvas.GetChild(0).GetComponent<Image>().sprite = null;
                DoorCanvas.GetChild(1).GetComponent<Image>().color = alphaZero;
                DoorCanvas.GetChild(1).GetComponent<Image>().sprite = null;
                DoorCanvas.GetChild(2).GetComponent<Image>().color = alphaZero;
                DoorCanvas.GetChild(2).GetComponent<Image>().sprite = null;
                DoorCanvas.GetChild(3).GetComponent<Image>().color = alphaZero;
                DoorCanvas.GetChild(3).GetComponent<Image>().sprite = null;
            }
        }
       
    }
	
	
}
