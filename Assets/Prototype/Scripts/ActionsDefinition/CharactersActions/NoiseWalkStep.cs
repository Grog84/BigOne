using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/NoiseWalkSteps")]
public class NoiseWalkStep : _Action {

    public override void Execute(CharacterStateController controller)
    {
        Step(controller);
    }

    private void Step(CharacterStateController controller)
    {
        for (int i = 0; i < GMController.instance.allEnemiesTransform.Length; i++)
        {
            float distance = Vector3.SqrMagnitude(controller.characterObj.CharacterTansform.position - GMController.instance.allEnemiesTransform[i].position);
            if (distance < controller.m_WalkSoundrange_sq)
            {
                EmitSound(controller);
            }
        }
    }

    private void EmitSound(CharacterStateController controller)
    {

    }
}
