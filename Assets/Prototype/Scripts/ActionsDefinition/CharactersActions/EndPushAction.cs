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
        if (!controller.m_CharacterController.isPushing)
        {
            controller.m_CharacterController.isPushLimit = false;
            controller.m_CharacterController.pushObject.transform.parent = null;                       // Detach the pushable object from the Player
            controller.m_CharacterController.pushObject.GetComponent<Rigidbody>().isKinematic = true;
            //controller.m_CharacterController.pushObject = null;
            //controller.m_CharacterController.pushCollider = null;
        }
    }
}


