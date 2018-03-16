using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateStateTrigger : MonoBehaviour {

    bool triggered;
    LevelQuestManager levelquests;
    public LevelQuestManager.QuestProgress questProgress;

    private void Start()
    {
        levelquests = FindObjectOfType<LevelQuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggered == false)
        {
            triggered = true;
            levelquests.updateState(questProgress);
        }
    }
}
