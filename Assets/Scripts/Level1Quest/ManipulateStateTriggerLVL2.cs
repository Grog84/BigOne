using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestManager;

public class ManipulateStateTriggerLVL2 : MonoBehaviour {

    bool triggered;
    QuestLivello2 level2Quest;
   

    private void Start()
    {
        level2Quest = FindObjectOfType<QuestLivello2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggered == false && level2Quest.Level2 == QuestLivello2.STATUSLEVELO2.Objective6)
        {
            triggered = true;
            level2Quest.Level2 = QuestLivello2.STATUSLEVELO2.Objective7;
        }
    }
}
