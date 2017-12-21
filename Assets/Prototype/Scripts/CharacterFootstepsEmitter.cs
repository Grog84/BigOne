using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class CharacterFootstepsEmitter : FootstepsEmitter
{
    public Transform[] origin;
    public LayerMask audioLayer;
    private _CharacterController controller;

    float maxAmount = 20f;
    float distance;
    float m;

    public void Awake()
    {
        controller = GetComponent<_CharacterController>();
    }

    public override void MakeStep()
    {
        base.MakeStep();

        // Controllo nemici a tiro d'orecchio

        for (int i = 0; i < GMController.instance.allEnemiesTransform.Length; i++)
        {
            Vector3 enemyPosition = GMController.instance.allEnemiesTransform[i].position;
            distance = Vector3.SqrMagnitude(controller.CharacterTransform.position - enemyPosition);
            //if (distance < controller.m_CharacterController.m_WalkSoundrange_sq * Mathf.Pow(controller.m_CharacterController.floorNoiseMultiplier, 2.0f))
            //Debug.Log(distance + " " + controller.m_SoundStatusRange);
            if (distance < controller.m_SoundStatusRange)
            {
                //Debug.Log(" Guard in Sound Range ");
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
            Debug.DrawRay(m_Ray.origin,m_Ray.direction,Color.blue);
            if (Physics.Raycast(m_Ray, out m_RayHit, controller.m_SoundStatusRange, audioLayer))
            {
                if (m_RayHit.transform.tag == "Enemy")
                {
                    GMController.instance.lastHeardPlayerPosition = controller.CharacterTransform.position;
                    var enemyController = m_RayHit.transform.GetComponent<Guard>();
                    float innerRange = controller.m_SoundStatusRange * controller.m_CharStats.m_InnerAreaPerc / 100f;
                    if (distance < innerRange)
                    {
                        enemyController.HearPlayer(maxAmount);
                    }
                    else
                    {
                        m = maxAmount / (controller.m_SoundStatusRange - innerRange);
                        enemyController.HearPlayer(maxAmount - m * (controller.m_SoundStatusRange - distance));
                    }
                    break;
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(controller.m_SoundStatusRange) * controller.m_ForwardAmount);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(controller.m_SoundStatusRange) * controller.m_ForwardAmount * 
            controller.m_CharStats.m_InnerAreaPerc / 100f);
    }

}
