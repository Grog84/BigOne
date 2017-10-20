using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/Animator/ActivatePatrol")]
public class AnimSetPatrolBoolTrue : _Action
{

    public override void Execute(EnemiesAIStateController controller)
    {
        UpdateAnimatorForStartPatrol(controller);
    }

    private void UpdateAnimatorForStartPatrol(EnemiesAIStateController controller)
    {
        controller.m_AgentController.m_Animator.SetBool("isPatrolling", true);

    }
}
