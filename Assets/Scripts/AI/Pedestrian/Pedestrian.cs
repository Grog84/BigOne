using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveGame;
using StateMachine;

namespace AI
{
    public class Pedestrian : AIAgent
    {
        public float sightRange = 20f;
        [Range(10, 50)]
        public int maxTimeSeen = 20;
        [Range(10, 90)]
        public float max_psi_Angle;
        [Range(10, 90)]
        public float max_theta_Angle;

        // Perception
        Transform[][] lookAtPositions;
        Transform[] lookAtPositionCentral;
        int timeSeenCounter = 0;
        Transform eyes;

        public LayerMask visionLayerMask;

        Vector3 currentWayPoint;
        float sightRangeSqr;

        // Updates the pointed nav point from the blackboard value
        public override void UpdateNavPoint()
        {
            m_NavMeshAgent.SetDestination(currentWayPoint);
            m_NavMeshAgent.isStopped = true;
        }

        // Commands to reach the point
        public override void ReachNavPoint()
        {
            m_NavMeshAgent.destination = currentWayPoint;
            m_NavMeshAgent.isStopped = false;
        }

        public void CheckPlayerDistance()
        {
            Vector3 playerPos = GMController.instance.playerTransform[(int)GMController.instance.isCharacterPlaying].position;

            if ((transform.position - playerPos).sqrMagnitude < sightRangeSqr)
            {
                m_Blackboard.SetBoolValue("PlayerInSight", true);
            }
            else
            {
                m_Blackboard.SetBoolValue("PlayerInSight", false);
            }

        }

        public void LookAtPlayer()
        {
            bool noRaycastHitting = true;

            if (GMController.instance.isCharacterPlaying == CharacterActive.None)
                return;

            Vector3 direction, distance;
            RaycastHit rayHit;
            bool isRayHitting;
            Ray ray;

            float angle_theta;
            float angle_psi;

            for (int i = 0; i < lookAtPositions[(int)GMController.instance.isCharacterPlaying].Length; i++)
            {
                distance = (lookAtPositions[(int)GMController.instance.isCharacterPlaying][i].position - eyes.position);
                angle_psi = Mathf.Abs(Mathf.Atan(distance.y / distance.z) * 180f / Mathf.PI);
                angle_theta = Mathf.Abs(Mathf.Atan(distance.x / distance.z) * 180f / Mathf.PI);
                direction = distance.normalized;

                if (angle_psi <= max_psi_Angle && angle_theta <= max_theta_Angle && Vector3.Dot(direction, transform.forward) > 0f)
                {
                    ray = new Ray(eyes.position, direction);
                    isRayHitting = Physics.Raycast(ray, out rayHit, sightRange, visionLayerMask);
                    isRayHitting = isRayHitting && rayHit.transform.tag == "Player" &&
                        rayHit.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying;

                    Debug.DrawLine(eyes.position, eyes.position + direction * sightRange, Color.red);

                    if (isRayHitting)
                    {
                        noRaycastHitting = false;
                        timeSeenCounter += 1;
                    }
                }
            }

            distance = (lookAtPositionCentral[(int)GMController.instance.isCharacterPlaying].position - eyes.position);
            angle_psi = Mathf.Atan(distance.y / distance.z) * 180f / Mathf.PI;
            angle_theta = Mathf.Atan(distance.x / distance.z) * 180f / Mathf.PI;
            direction = distance.normalized;

            if (angle_psi <= max_psi_Angle && angle_theta <= max_theta_Angle && Vector3.Dot(direction, transform.forward) > 0f)
            {
                ray = new Ray(eyes.position, direction);
                isRayHitting = Physics.Raycast(ray, out rayHit, sightRange, visionLayerMask);
                isRayHitting = isRayHitting && rayHit.transform.tag == "Player" &&
                    rayHit.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying;

                if (isRayHitting)
                {
                    noRaycastHitting = false;
                    timeSeenCounter += 2;
                }
            }


            if (noRaycastHitting)
            {
                timeSeenCounter = 0;
                m_Blackboard.SetBoolValue("PlayerIsVisible", false);
            }
            else
            {
                if (timeSeenCounter > maxTimeSeen)
                {
                    m_Blackboard.SetBoolValue("PlayerIsVisible", true);
                }
            }

        }

        public void CheckPlayerClimbing()
        {
            // TODO    mettere il riferimento all'altezza eccessiva anziche questo bool messo a caso come segnaposto
            bool isPlayerClimbing = GMController.instance.m_CharacterInterfaces[(int)GMController.instance.isCharacterPlaying].m_CharController.isClimbCRDone;
            m_Blackboard.SetBoolValue("PlayerIsClimbing", isPlayerClimbing);
        }

        public void DefeatPlayer()
        {
            if (GMController.instance.isCharacterPlaying == CharacterActive.Boy || GMController.instance.isCharacterPlaying == CharacterActive.Mother)
                GMController.instance.m_CharacterInterfaces[(int)GMController.instance.isCharacterPlaying].DefeatPlayer();
        }

        public void PickNewDestination()
        {
            // TODO     metodo per prendere una nuova destinazione
        }

        private void Awake()
        {
            sightRangeSqr = sightRange * sightRange;

            GameObject[] lookAtPositionsObj = GameObject.FindGameObjectsWithTag("LookAtPosition");
            lookAtPositions = new Transform[2][];
            lookAtPositions[0] = new Transform[lookAtPositionsObj.Length / 2];
            lookAtPositions[1] = new Transform[lookAtPositionsObj.Length / 2];

            eyes = TransformDeepChildExtension.FindDeepChild(transform, "eyes");
        }

    }
}