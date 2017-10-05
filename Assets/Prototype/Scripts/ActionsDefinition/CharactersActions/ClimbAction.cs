using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Climb")]
public class ClimbAction : _Action
{
    Vector3 m_Move;


    public override void Execute(CharacterStateController controller)
    {
        Climb(controller);
    }

    private void Climb(CharacterStateController controller)
    {
        m_Move = new Vector3(0, 0, Input.GetAxis("Vertical"));
        controller.characterObj.m_CharController.Move(m_Move * Time.deltaTime * controller.characterStats.m_ClimbSpeed);
        if (m_Move != Vector3.zero)
            controller.characterObj.CharacterTansform.up = m_Move;
    }
}
