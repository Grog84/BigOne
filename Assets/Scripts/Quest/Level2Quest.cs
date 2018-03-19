using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Character;

using UnityEngine.Playables;

public class Level2Quest : LevelQuestManager
{
    bool played = false;



    public override void updateState(QuestProgress newState)
    {
        if (newState == QuestProgress.Objective1)
        {
            actualQuest = QuestProgress.Objective1;
            objectiveProgress.enabled = false;
            objectiveText.text = Objectives[0];
        }
        if (newState == QuestProgress.Objective2)
        {
            actualQuest = QuestProgress.Objective2;      
            StartCoroutine(CompleteQuest(Objectives[1], ""));
        }
        if (newState == QuestProgress.Objective3)
        {
            actualQuest = QuestProgress.Objective3;
            Cutscenes[0].Play();
            Mother.GetComponent<_CharacterController>().isCarrying = true;
            StartCoroutine(CompleteQuest(Objectives[2], ""));
        }
        if (newState == QuestProgress.Objective4)
        {
            actualQuest = QuestProgress.Objective4;
            Mother.GetComponent<_CharacterController>().isCarrying = false;
            StartCoroutine(CompleteQuest(Objectives[0], ""));
        }
        if (newState == QuestProgress.Objective5)
        {
            actualQuest = QuestProgress.Objective5;
            Cutscenes[1].Play();
            StartCoroutine(CompleteQuest(Objectives[3], ""));
        }
        if (newState == QuestProgress.Objective6)
        {
            actualQuest = QuestProgress.Objective6;
            Cutscenes[2].Play();
            StartCoroutine(CompleteQuest(Objectives[4], ""));
        }
        if (newState == QuestProgress.Objective7)
        {
            actualQuest = QuestProgress.Objective7;
            Cutscenes[3].Play();
            StartCoroutine(CompleteQuest(Objectives[5], ""));
        }
    }

}
