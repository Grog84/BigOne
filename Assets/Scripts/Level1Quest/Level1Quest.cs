using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Playables;

public class Level1Quest : CutsceneManager
{

    public Text objectiveText;
    public Text objectiveProgress;
    bool played = false;
    public enum QuestProgress { FreeFriends, SearchBall, HideFromMother, FindYourSon }
    public int friendsSaved = 0;

    public string[] objectivesDescription;

    public QuestProgress actualQuest;

    private void Start()
    {
        updateState(QuestProgress.FreeFriends);
    }

    private void Update()
    {
        objectiveProgress.text = friendsSaved.ToString();
        if (friendsSaved == 3 && played == false)
        {
            played = true;
            updateState(QuestProgress.SearchBall);
        }
    }

    public void updateState(QuestProgress newState)
    {
        if (newState == QuestProgress.FreeFriends)
        {
            objectiveProgress.enabled = true;
            objectiveText.text = objectivesDescription[0];
            objectiveProgress.text = friendsSaved.ToString();
        }
        if (newState == QuestProgress.SearchBall)
        {
            objectiveProgress.enabled = false;
            actualQuest = QuestProgress.SearchBall;
            StartCoroutine(PlayTimeline(m_PlayableDirector));
            objectiveText.text = objectivesDescription[1];
        }
        if (newState == QuestProgress.HideFromMother)
        {
            actualQuest = QuestProgress.HideFromMother;
            objectiveText.text = objectivesDescription[2];
        }
        if (newState == QuestProgress.FindYourSon)
        {
            actualQuest = QuestProgress.FindYourSon;
            objectiveText.text = objectivesDescription[3];
        }
    }

}
