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
        controller.m_CharacterController.pushCollider.transform.DOMove(controller.m_CharacterController.CharacterTansform.Find("PushPoint").position, 0.1f);
        // Rotate the player to a straigth direction
        
    }
}

