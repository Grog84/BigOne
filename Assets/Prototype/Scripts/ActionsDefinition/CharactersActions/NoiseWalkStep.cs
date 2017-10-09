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
            Vector3 enemyPosition = GMController.instance.allEnemiesTransform[i].position;
            float distance = Vector3.SqrMagnitude(controller.m_CharacterController.CharacterTansform.position - enemyPosition);
            if (distance < controller.m_WalkSoundrange_sq)
            {
                EmitSound(controller, enemyPosition);
            }
        }
    }

    private void EmitSound(CharacterStateController controller, Vector3 enemyPosition)
    {
        Vector3 origin = controller.m_CharacterController.CharacterTansform.position;
        Vector3 direction = (origin - enemyPosition).normalized;
        Ray m_Ray = new Ray(origin, direction);
        RaycastHit m_RayHit = new RaycastHit();

        Physics.Raycast(m_Ray, out m_RayHit, controller.m_CharacterController.m_WalkNoiseLayerMask);

        if (m_RayHit.transform.tag == "Enemy")
        {
            var enemyController = m_RayHit.transform.GetComponent<_AgentController>();
            enemyController.hasHeardPlayer = true;
        }

    }
}
