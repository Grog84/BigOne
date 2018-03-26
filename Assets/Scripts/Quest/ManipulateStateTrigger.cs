using System.Collections;
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
        if(transform.parent)
        {
            isNpc = transform.parent.name.Contains("NpcQuest");
        }
        else
        {
            isNpc = transform.name.Contains("NpcQuest");
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
