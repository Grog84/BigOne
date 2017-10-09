using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Prototype/CharactersActions/Push")]
public class PushAction : _Action
{
    Vector3 m_Move;

    float forward;

    public override void Execute(CharacterStateController controller)
    {
        Push(controller);
    }

    private void Push(CharacterStateController controller)
    {
        


        if (Input.GetKey(KeyCode.W))
        {
            forward = Input.GetAxis("Vertical");
        }
        else
        {
            forward = 0;
        }

        if (!controller.m_CharacterController.isPushLimit)
        {
            controller.m_CharacterController.CharacterTansform.Translate(Vector3.forward * forward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
        }
    }
}

