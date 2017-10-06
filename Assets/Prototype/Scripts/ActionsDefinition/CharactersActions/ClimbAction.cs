using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Climb")]
public class ClimbAction : _Action
{
    Vector3 m_Move;
    float up;
    float down;

    public override void Execute(CharacterStateController controller)
    {
        Climb(controller);
    }

    private void Climb(CharacterStateController controller)
    {
         controller.m_CharacterController.charSize = controller.m_CharacterController.m_CharController.bounds.size.y;
         controller.m_CharacterController.charDepth = controller.m_CharacterController.m_CharController.bounds.size.z;

        if (Input.GetKey(KeyCode.W))
        {
            up = Input.GetAxis("Vertical");
        }
        else
        {
            up = 0;
        }

        if (Input.GetKey(KeyCode.S))
        {
            down = Input.GetAxis("Vertical");
        }
        else
        {
            down = 0;
        }

        if (!controller.m_CharacterController.climbingTop)
        {
            controller.m_CharacterController.CharacterTansform.Translate(Vector3.up * up * controller.characterStats.m_ClimbSpeed * Time.deltaTime);//0.0.1
        }
        if (!controller.m_CharacterController.climbingBottom)
        {
            controller.m_CharacterController.CharacterTansform.Translate(Vector3.up * down * controller.characterStats.m_ClimbSpeed * Time.deltaTime);//0.0.1
        }
    }
}
