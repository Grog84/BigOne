using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Prototype/CharactersActions/EndPush")]
public class EndPushAction : _Action
{
   

    public override void Execute(CharacterStateController controller)
    {
        EndPush(controller);
    }

    private void EndPush(CharacterStateController controller)
    {
        controller.m_CharacterController.isExitPush = true;  
        controller.m_CharacterController.isPushLimit = false;
        controller.m_CharacterController.pushCollider.transform.parent = null;                       // Detach the pushable object from the Player
        controller.m_CharacterController.pushCollider.GetComponent<Rigidbody>().isKinematic = true;
    }
}

