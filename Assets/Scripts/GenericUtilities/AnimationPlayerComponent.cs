using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationPlayerComponent : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo stateInfo;
    float targetAnimationTime = 0, currentAnimationTime = 0;


    public void SetAnimator(Animator thisAnim)
    {
        anim = thisAnim;
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
    }

	// Update is called once per frame
	void Update () {

        if (anim != null)
        {
            if (anim.speed == 1f)
            {
                if (currentAnimationTime <= targetAnimationTime)
                {
                    currentAnimationTime = stateInfo.normalizedTime;
                    return;
                }
            }
            else
            {
                if (currentAnimationTime >= targetAnimationTime)
                {
                    currentAnimationTime = stateInfo.normalizedTime;
                    return;
                }
            }

            anim.speed = 0f;
            Destroy(this);
        }

    }
}
