using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using DG.Tweening;

public class LevelQuestManager : MonoBehaviour
{

    public string[] Objectives;
    public PlayableDirector[] Cutscenes;
    public enum QuestProgress { Objective1, Objective2, Objective3, Objective4, Objective5, Objective6, Objective7 }
    protected Text objectiveText;
    protected Text objectiveProgress;
    protected Image objectiveComplete;

    protected GameObject Mother;
    protected GameObject Boy;

    public QuestProgress actualQuest;

    public virtual void updateState(QuestProgress newState) { }

    private void Start()
    {
        Mother = GameObject.Find("Mother");
        Boy = GameObject.Find("Boy");
        objectiveText = GameObject.Find("Objective").GetComponent<Text>();
        objectiveProgress = GameObject.Find("ObjectiveProgress").GetComponent<Text>();
        objectiveComplete = GameObject.Find("ObjectiveComplete").GetComponent<Image>();
        updateState(QuestProgress.Objective1);
    }


    public IEnumerator CompleteQuest(string nextObjective, string myObjectiveProgress)
    {
        objectiveComplete.DOColor(new Color(objectiveComplete.color.r, objectiveComplete.color.g, objectiveComplete.color.b, 255f), 2f);
        yield return new WaitForSeconds(2.5f);
        objectiveComplete.DOColor(new Color(objectiveComplete.color.r, objectiveComplete.color.g, objectiveComplete.color.b, 0f), 1f);
        yield return new WaitForSeconds(1f);
        objectiveText.text = nextObjective;
        objectiveProgress.text = myObjectiveProgress;
        yield return null;
    }
}
