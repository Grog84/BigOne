using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/InAir")]
public class InAirAction : _Action
{

    Vector3 m_Velocity;

    public override void Execute(CharacterStateController controller)
    {
        AirbornMovement(controller);
    }

    private void AirbornMovement(CharacterStateController controller)
    {
        m_Velocity = controller.m_CharacterController.m_CharController.velocity;
        m_Velocity.y += controller.characterStats.m_Gravity * Time.deltaTime;
        controller.m_CharacterController.m_CharController.Move(m_Velocity * Time.deltaTime);
    }
}
