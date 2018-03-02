using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateStateTrigger : MonoBehaviour {

    bool triggered;
    Level1Quest level1quest;
    public Level1Quest.QuestProgress questProgress;

    private void Start()
    {
        level1quest = FindObjectOfType<Level1Quest>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggered == false)
        {
            triggered = true;
            level1quest.updateState(questProgress);
        }
    }
}
