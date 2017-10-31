using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class CharacterFootstepsEmitter : FootstepsEmitter
{
    public Transform[] origin;
    private _CharacterController controller;

    public void Awake()
    {
        controller = GetComponent<_CharacterController>();
    }

    public override void MakeStep()
    {
        base.MakeStep();
        //Debug.Log(controller.m_WalkSoundrange_sq);

        // Controllo nemici a tiro d'orecchio

        for (int i = 0; i < GMController.instance.allEnemiesTransform.Length; i++)
        {
            Vector3 enemyPosition = GMController.instance.allEnemiesTransform[i].position;
            float distance = Vector3.SqrMagnitude(controller.CharacterTransform.position - enemyPosition);
            //if (distance < controller.m_CharacterController.m_WalkSoundrange_sq * Mathf.Pow(controller.m_CharacterController.floorNoiseMultiplier, 2.0f))
            if (distance < controller.m_WalkSoundrange_sq)
            {
                //Debug.Log(" Guard in Range ");
                EmitSound(enemyPosition);
            }
        }

        // Per nemici a tiro d'orecchio vedere se sentono
    }

    public void EmitSound(Vector3 enemyPosition)
    {
        for (int i = 0; i < origin.Length; i++)
        {
          
            Vector3 direction = ((enemyPosition + Vector3.up * 0.5f) - origin[i].position).normalized;
            Ray m_Ray = new Ray(origin[i].position, direction);
            RaycastHit m_RayHit = new RaycastHit();

            // Raycast da player a nemico 
            Debug.DrawRay(m_Ray.origin,m_Ray.direction,Color.red);
            if (Physics.Raycast(m_Ray, out m_RayHit, controller.m_WalkSoundrange_sq))
            {
                if (m_RayHit.transform.tag == "Enemy")
                {
                    GMController.instance.lastHeardPlayerPosition = controller.CharacterTransform.position;
                    var enemyController = m_RayHit.transform.GetComponent<_AgentController>();
                    enemyController.hasHeardPlayer = true;
                    Debug.Log("Ahah!");

                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(controller.m_WalkSoundrange_sq));
    }

}
