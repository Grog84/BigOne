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
    bool isNpc;


    Transform IconCanvas;
    public Sprite talk;
    public Sprite objective;
    public Sprite talkJoystick;
    Collider perception;
    public int degrees;
    float talkSize = 0.7f;
    float objectiveSize = 1f;
    [HideInInspector]
    public bool isActive = false;
    bool isInside = false;

    [HideInInspector]
    public Color alphaZero;
    [HideInInspector]
    public Color alphaMax;
    [HideInInspector]
    public Transform talkIcon;
    [HideInInspector]
    public Transform activePlayer;

    void Awake()
    {
        alphaZero = new Color(0, 0, 0, 0);
        alphaMax = new Color(100, 100, 100, 255);
        levelquests = FindObjectOfType<LevelQuestManager>();
    }

    private void Start()
    {
        perception = GetComponent<BoxCollider>();
        IconCanvas = transform.GetChild(0).transform;
        talkIcon = IconCanvas.GetChild(0);
        if (transform.parent)
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
        isActive = levelquests.actualQuest == questProgress - 1;
        if (isActive && GMController.instance.isCharacterPlaying == CharacterActive.Mother && !isInside)
        {
            SetToObjective();
            //ShowIcon(levelquests.Mother);
        }
        else if (isActive && GMController.instance.isCharacterPlaying == CharacterActive.Boy && !isInside)
        {
            SetToObjective();
            //ShowIcon(levelquests.Boy);
        }
        else if (!isActive)
        {
            HideIcons();
        }
    }

    public void HideIcons()
    {

        talkIcon.GetChild(0).GetComponent<Image>().sprite = null;
    }

    public void SetToObjective()
    {
        talkIcon.GetChild(0).GetComponent<Image>().color = alphaMax;
        talkIcon.GetChild(0).GetComponent<Image>().sprite = objective;
        talkIcon.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2(objectiveSize, objectiveSize);
    }

    public void SwapIcons()
    {
        if(InputManager.instance.GetInputState() == InputManager.InputState.MouseKeyboard)
        {
            talkIcon.GetChild(0).GetComponent<Image>().sprite = talk;
        }
        else if(InputManager.instance.GetInputState() == InputManager.InputState.Controller)
        {
            talkIcon.GetChild(0).GetComponent<Image>().sprite = talkJoystick;
        }

        talkIcon.GetChild(0).GetComponent<Image>().color = alphaMax;
        talkIcon.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2(talkSize, talkSize);
    }

    public void ShowIcon(GameObject player)
    {
        CharacterStateController playerState = player.GetComponent<CharacterStateController>();

        if (GMController.instance.isCharacterPlaying == playerState.thisCharacter)
        {
            activePlayer = Camera.main.transform;
            // Npc icon                       
            if (playerState.thisCharacter == CharacterActive.Mother && !playerState.m_CharacterController.isPushDirectionRight ||
                    playerState.thisCharacter == CharacterActive.Boy && !playerState.m_CharacterController.isClimbDirectionRight)
            {
                Debug.Log("asdasd");
                SwapIcons();
                player.GetComponent<_CharacterController>().IconPriority(talkIcon, degrees);
                //talkIcon.DOLookAt(activePlayer.position, 0.1f);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isNpc)
        {
            if (other.tag == "Player" && triggered == false && isActive)
            {
                ShowIcon(other.gameObject);
                if (Input.GetButtonDown("Interact"))
                {
                    triggered = true;
                    levelquests.UpdateState(questProgress);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isNpc)
        {
            if (other.tag == "Player" && triggered == false && isActive)
            {
                triggered = true;
                levelquests.UpdateState(questProgress);
            }
        }
        if (isNpc && isActive && other.tag == "Player")
        {
            isInside = true;
            ShowIcon(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isNpc && isActive && other.tag == "Player")
        {
            isInside = false;
            //ShowIcon(other.gameObject);
        }
    }
}
