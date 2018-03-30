using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using StateMachine;
using Character;



public class ManipulateStateTrigger : MonoBehaviour
{

    bool triggered;
    LevelQuestManager levelquests;
    public LevelQuestManager.QuestProgress questProgress;
    [SerializeField]bool isNpc;

    public Transform IconCanvas;
    public Sprite talk;
    public Sprite objective;
    public Collider perception;
    public int degrees;
    public float talkSize;
    public float objectiveSize;
    [HideInInspector]
    public bool isActive = false;

    [HideInInspector]
    public Color alphaZero;
    [HideInInspector]
    public Color alphaMax;
    [HideInInspector]
    public Transform talkIcon;
    [HideInInspector]
    public Transform activePlayer;


    private void Start()
    {
        levelquests = FindObjectOfType<LevelQuestManager>();
        if(transform.parent)
        {
            isNpc = transform.parent.name.Contains("NpcQuest");
        }
        else
        {
            isNpc = transform.name.Contains("NpcQuest");
        }
    }

    private void Update()
    {
        talkIcon.DOLookAt(Camera.main.transform.position, 0.1f);
        if(levelquests.actualQuest == questProgress -1 )
        {

        }
    }

    public void HideIcons()
    {
        talkIcon.GetChild(0).GetComponent<Image>().color = alphaZero;
        talkIcon.GetChild(0).GetComponent<Image>().sprite = null;
    }

    public void SetToObjective()
    {
        talkIcon.GetChild(0).GetComponent<Image>().color = alphaMax;
        talkIcon.GetChild(0).GetComponent<Image>().sprite = objective;
        talkIcon.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2(objectiveSize, objectiveSize);
    }

    public void SwapIcons(Transform orientation, CharacterStateController playerState)
    {
        orientation.GetChild(0).GetComponent<Image>().sprite = talk;
        orientation.GetChild(0).GetComponent<Image>().color = alphaMax;
        talkIcon.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2(talkSize, talkSize);
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
                    //talkIcon.DOLookAt(activePlayer.position, 0.1f);
                }
            }

            else
            {
                if (isActive)
                {
                    SetToObjective();
                }
                else
                {
                    HideIcons();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isNpc)
        {
            if (other.tag == "Player" && triggered == false && Input.GetButtonDown("Interact") && levelquests.actualQuest == questProgress - 1)
            {
                triggered = true;
                levelquests.UpdateState(questProgress);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isNpc)
        {
            if (other.tag == "Player" && triggered == false && levelquests.actualQuest == questProgress - 1)
            {
                triggered = true;
                levelquests.UpdateState(questProgress);
            }
        }
    }
}
