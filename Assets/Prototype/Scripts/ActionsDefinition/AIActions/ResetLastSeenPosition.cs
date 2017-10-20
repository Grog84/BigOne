using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/ResetLastSeenPosition")]
public class ResetLastSeenPosition : _Action
{
    public override void Execute(EnemiesAIStateController controller)
    {
        ResetPos(controller);
    }

    private void ResetPos(EnemiesAIStateController controller)
    {
        GMController.instance.ResetPlayerLastSeenPosition();
    }
}
