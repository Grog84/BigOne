using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;
using Character;
using DG.Tweening;

public class NpcQuestIcons : MonoBehaviour
{
    public Transform IconCanvas;
    public Sprite talk;
    public Collider perception;
    public int degrees;

    [HideInInspector] public Color alphaZero;
    [HideInInspector] public Color alphaMax;
    [HideInInspector] public Transform talkIcon;
    [HideInInspector] public Transform activePlayer;

    void Awake()
    {
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100, 100, 100, 255);

        talkIcon = IconCanvas.GetChild(0);
    }

    public void HideIcons()
    {
        talkIcon.GetChild(0).GetComponent<Image>().color = alphaZero;
        talkIcon.GetChild(0).GetComponent<Image>().sprite = null;
    }

    public void SwapIcons(Transform orientation, CharacterStateController playerState)
    {
       orientation.GetChild(0).GetComponent<Image>().sprite = talk;
       orientation.GetChild(0).GetComponent<Image>().color = alphaMax;
    }

    public void ShowIcon(GameObject player)
    {
        CharacterStateController playerState = player.GetComponent<CharacterStateController>();

        if (GMController.instance.isCharacterPlaying == playerState.thisCharacter)
        {
            activePlayer = player.GetComponent<_CharacterController>().m_Camera;
            // Npc icon                       
            if (playerState.thisCharacter == CharacterActive.Mother && !playerState.m_CharacterController.isPushDirectionRight ||
                    playerState.thisCharacter == CharacterActive.Boy && !playerState.m_CharacterController.isClimbDirectionRight)
            {
               if (playerState.m_CharacterController.npcSightCollider.transform == perception.transform)
               {
                  SwapIcons(talkIcon, playerState);
                  player.GetComponent<_CharacterController>().IconPriority(talkIcon, degrees);
                  talkIcon.DOLookAt(activePlayer.position, 0.1f);

               }             
            }
            
            else
            {
                HideIcons();
            }

        }

    }

}
