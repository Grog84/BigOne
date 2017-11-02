using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAvoidance : MonoBehaviour {

    [HideInInspector] public float myOrder = 0f;

    [HideInInspector] public NavMeshAgent m_NavmeshAgent;
    [HideInInspector] public NavMeshObstacle m_NavmeshObstacle;

    private void Awake()
    {
        m_NavmeshAgent = GetComponent<NavMeshAgent>();
        m_NavmeshObstacle = GetComponent<NavMeshObstacle>();
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
    }
}
