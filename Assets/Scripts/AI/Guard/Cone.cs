using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

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
            if (other.tag == "Player" && other.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying)
            {
                m_Guard.SetBlackboardValue("PlayerInSight", true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player" && other.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying)
            {
                StartCoroutine(m_Guard.OutOfSightHysteresis());
            }
        }

    }
}
