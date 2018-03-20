using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Character;

using UnityEngine.Playables;

public class Level4Quest : LevelQuestManager
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
            StartCoroutine(WaitForCutscene(Cutscenes[0]));
        }
        if (newState == QuestProgress.Objective3)
        {
            actualQuest = QuestProgress.Objective3;
            StartCoroutine(CompleteQuest(Objectives[2], ""));
        }
        
    }

}
