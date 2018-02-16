using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AI;

public class AgentAvoidance : MonoBehaviour {

    [HideInInspector] public float myOrder = 0f;

    [HideInInspector] public Guard m_Guard;
    [HideInInspector] public NavMeshAgent m_NavmeshAgent;
    [HideInInspector] public NavMeshObstacle m_NavmeshObstacle;

    private void Awake()
    {
        m_NavmeshAgent = GetComponentInParent<NavMeshAgent>();
        m_NavmeshObstacle = GetComponentInParent<NavMeshObstacle>();
        m_Guard = GetComponentInParent<Guard>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            myOrder = Random.value;
            var otherAgentAvoidance = other.gameObject.GetComponent<AgentAvoidance>();
            if (myOrder < otherAgentAvoidance.myOrder)
            {
                m_NavmeshAgent.enabled = false;
                m_NavmeshObstacle.enabled = true;

                otherAgentAvoidance.m_NavmeshObstacle.enabled = false;
                otherAgentAvoidance.m_NavmeshAgent.enabled = true;
            }
        }

        else if (other.tag == "Player")
        {
            m_Guard.playerInCollisionArea = true;
            m_Guard.GetAlarmed();
            m_Guard.UpdateLastPercievedDestination();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var otherAgentAvoidance = other.gameObject.GetComponent<AgentAvoidance>();
            if (myOrder < otherAgentAvoidance.myOrder)
            {
                m_NavmeshObstacle.enabled = false;
                m_NavmeshAgent.enabled = true;

                otherAgentAvoidance.m_NavmeshObstacle.enabled = false;
                otherAgentAvoidance.m_NavmeshAgent.enabled = true;
            }
        }

        else if (other.tag == "Player")
        {
            m_Guard.playerInCollisionArea = false;
        }
    }
}
