using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationPlayer
{

    public static void PlayUntilTime(this Animator anim, float normalizedTime)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float currentAnimationTime = stateInfo.normalizedTime;
        float animationSpeed;

        if (normalizedTime < currentAnimationTime)
            animationSpeed = -1f;
        else if (normalizedTime > currentAnimationTime)
            animationSpeed = 1f;
        else
            return;

        anim.speed = animationSpeed;

        var comp = anim.gameObject.AddComponent<AnimationPlayerComponent>();
        comp.SetAnimator(anim);

    }


}
