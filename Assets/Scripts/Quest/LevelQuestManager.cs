using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using DG.Tweening;


public class LevelQuestManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string soundEffect;
    public string[] Objectives;
    public PlayableDirector[] Cutscenes;
    ManipulateStateTrigger[] ObjectiveTriggers;
    public enum QuestProgress { Objective1, Objective2, Objective3, Objective4, Objective5, Objective6, Objective7, Objective8 }
    protected Text objectiveText;
    protected Text objectiveProgress;
    protected Image objectiveComplete;



    protected GameObject Mother;
    protected GameObject Boy;

    public QuestProgress actualQuest;

    public virtual void UpdateState(QuestProgress newState) { }

    private void Start()
    {
        Mother = GameObject.Find("Mother");
        Boy = GameObject.Find("Boy");
        objectiveText = GameObject.Find("Objective").GetComponent<Text>();
        objectiveProgress = GameObject.Find("ObjectiveProgress").GetComponent<Text>();
        objectiveComplete = GameObject.Find("ObjectiveComplete").GetComponent<Image>();
        ObjectiveTriggers = FindObjectsOfType<ManipulateStateTrigger>();
        UpdateState(QuestProgress.Objective1);
    }


    public IEnumerator CompleteQuest(string nextObjective, string myObjectiveProgress)
    {
        FMOD.Studio.EventInstance fmodEvent = FMODUnity.RuntimeManager.CreateInstance(soundEffect);
        fmodEvent.start();
        fmodEvent.release();
        objectiveComplete.DOColor(new Color(objectiveComplete.color.r, objectiveComplete.color.g, objectiveComplete.color.b, 255f), 2f);
        yield return new WaitForSeconds(2.5f);
        objectiveComplete.DOColor(new Color(objectiveComplete.color.r, objectiveComplete.color.g, objectiveComplete.color.b, 0f), 1f);
        yield return new WaitForSeconds(1f);
        objectiveText.text = nextObjective;
        objectiveProgress.text = myObjectiveProgress;
        yield return null;
    }

    public IEnumerator WaitForCutscene(PlayableDirector currentCutscene)
    {
        currentCutscene.Play();
        if (currentCutscene.playableGraph.IsPlaying())
        {
            //Debug.Log("INIZIATO");
            GMController.instance.SetActive(false);
        }

        yield return new WaitForSeconds((float)currentCutscene.duration);

        if (currentCutscene.state != PlayState.Playing)
        {
            //Debug.Log("FINITO");
            GMController.instance.SetActive(true);
        }
    }

    public void CheckActualObjective()
    {
        for (int i = 0; i < ObjectiveTriggers.Length; i++)
        {
            if(ObjectiveTriggers[i].questProgress - 1 == actualQuest)
            {
                ObjectiveTriggers[i].isActive = true;
            }
        }
    }

}
