using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI
{
    public class Cone : MonoBehaviour
    {
        private Guard m_Guard;
        public float raycastLength;
        public float max_theta_Angle, max_psi_Angle;

        private void Awake()
        {
            m_Guard = GetComponentInParent<Guard>();
            UpdateRaycastParams();
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

        public void UpdateRaycastParams()
        {
            Mesh m_Mesh = GetComponent<MeshFilter>().sharedMesh;
            Vector3 bounds = m_Mesh.bounds.extents;
            raycastLength = bounds.z * 2f * transform.localScale.z;

            max_theta_Angle = Mathf.Atan((bounds.x * transform.localScale.x) / raycastLength) * 180f / Mathf.PI;
            max_psi_Angle = Mathf.Atan((bounds.y * transform.localScale.y) / raycastLength) * 180f / Mathf.PI;

        }

    }
}
