using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Chase")]
public class M_WalkAction : _Action
{

    public override void Execute(StateController controller)
    {
        Walk(controller);
    }

    private void Walk(StateController controller)
    {
        controller.navMeshAgent.destination = controller.chaseTarget.position;
        controller.navMeshAgent.isStopped = false;
    }
}
