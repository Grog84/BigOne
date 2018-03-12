using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[Serializable]
public class SwitchSceneBehaviour : PlayableBehaviour
{
    [HideInInspector] public bool SceneSwitched;
    
    //public string nextScene;

    public override void OnGraphStart (Playable playable)
    {
        
        SceneSwitched = false;
    }
}
