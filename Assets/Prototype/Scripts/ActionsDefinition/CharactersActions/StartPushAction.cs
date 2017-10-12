using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu(menuName = "Prototype/CharactersActions/StartPush")]
public class StartPushAction : _Action
{
    

    public override void Execute(CharacterStateController controller)
    {
        StartPush(controller);
    }

    private void StartPush(CharacterStateController controller)
    {
        controller.m_CharacterController.pushableName = controller.m_CharacterController.pushCollider.GetComponent<ObjectPush>().name;
        controller.m_CharacterController.pushCollider.transform.SetParent(controller.m_CharacterController.CharacterTansform);  // Set the pushable object as Child
        controller.m_CharacterController.pushCollider.GetComponent<Rigidbody>().isKinematic = false;
        // Rotate player the a straigth direction
    }
}

