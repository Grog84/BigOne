using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveGame;

namespace AI
{
    public class Pedestrian : AIAgent
    {
        public float sightRange = 5f;

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

        private void Awake()
        {
            sightRangeSqr = sightRange * sightRange;
        }

    }
}