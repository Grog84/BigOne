using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Cone : MonoBehaviour
    {

        private Guard m_Guard;

        private void Awake()
        {
            m_Guard = GetComponentInParent<Guard>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                m_Guard.SetBlackboardValue("PlayerInSight", true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(m_Guard.OutOfSightHysteresis());
            }
        }

    }
}
