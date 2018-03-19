﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateStateTrigger : MonoBehaviour
{

    bool triggered;
    LevelQuestManager levelquests;
    public LevelQuestManager.QuestProgress questProgress;
    bool isNpc;

    private void Start()
    {
        levelquests = FindObjectOfType<LevelQuestManager>();
        isNpc = transform.parent.name.Contains("NpcQuest");       
    }

    private void OnTriggerStay(Collider other)
    {
        if (isNpc)
        {
            if (other.tag == "Player" && triggered == false && Input.GetButtonDown("Interact"))
            {
                triggered = true;
                levelquests.updateState(questProgress);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isNpc)
        {
            if (other.tag == "Player" && triggered == false)
            {
                triggered = true;
                levelquests.updateState(questProgress);
            }
        }
    }
}
