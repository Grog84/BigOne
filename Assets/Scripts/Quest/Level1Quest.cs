using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Playables;

public class Level1Quest : LevelQuestManager
{
    public int friendsSaved = 0;
    bool played = false;

    private void Update()
    {
        objectiveProgress.text = friendsSaved.ToString();
        if (friendsSaved == 3 && played == false)
        {
            played = true;
            updateState(QuestProgress.Objective2);
        }
    }

    public override void updateState(QuestProgress newState)
    {
        if (newState == QuestProgress.Objective1)
        {
            actualQuest = QuestProgress.Objective1;
            objectiveProgress.enabled = true;
            objectiveText.text = Objectives[0];
        }
        if (newState == QuestProgress.Objective2)
        {
            objectiveProgress.enabled = false;
            actualQuest = QuestProgress.Objective2;
            Cutscenes[0].Play();
            
            StartCoroutine(CompleteQuest(Objectives[1], ""));
        }
        if (newState == QuestProgress.Objective3)
        {
            actualQuest = QuestProgress.Objective3;
            StartCoroutine(CompleteQuest(Objectives[2], ""));
           
        }
        if (newState == QuestProgress.Objective4)
        {
            actualQuest = QuestProgress.Objective4;
            StartCoroutine(CompleteQuest(Objectives[3], ""));
           
        }
    }

}
