using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class AnimationTriggerGuardBehaviour : PlayableBehaviour
{
    public Animator Guard;
    public Animator RunBool;
    public AnchoredJoint2D WalkBool;

    public override void OnGraphStart (Playable playable)
    {
        
    }
}
