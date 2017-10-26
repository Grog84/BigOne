using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Cone : MonoBehaviour
    {

        private _AgentController m_AgentController;

        private void Awake()
        {
            m_AgentController = GetComponentInParent<_AgentController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                m_AgentController.isPlayerInSight = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                m_AgentController.isPlayerInSight = false;
            }
        }

    }
}
