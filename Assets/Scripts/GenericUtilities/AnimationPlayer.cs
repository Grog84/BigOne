using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationPlayer
{

    public static void PlayTime(this Animator anim, float normalizedTime)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float currentAnimationTime = stateInfo.normalizedTime;
        anim.Play(stateInfo.fullPathHash, 0, normalizedTime);

    }


}
