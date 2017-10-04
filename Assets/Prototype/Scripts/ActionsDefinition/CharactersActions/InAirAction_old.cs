using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/AirbornMovement")]
public class InAirAction_old : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        AirbornMovement(controller);
    }

    private void AirbornMovement(CharacterStateController controller)
    {
        // apply extra gravity from multiplier:
        Vector3 extraGravityForce = (Physics.gravity * controller.characterStats.m_GravityMultiplier) - Physics.gravity;
        controller.characterObj.m_Rigidbody.AddForce(extraGravityForce);
    }
}
