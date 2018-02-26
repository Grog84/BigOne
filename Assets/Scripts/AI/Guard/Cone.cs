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

        Mesh m_Mesh;

        private void Awake()
        {
            m_Mesh = GetComponent<MeshFilter>().sharedMesh;
            m_Guard = GetComponentInParent<Guard>();
            //Debug.Log("Called updateraycast");
            // UpdateRaycastParams();
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && other.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying)
            {
                
                //Debug.Log("Player Enter Cone");
                m_Guard.SetBlackboardValue("PlayerInCone", true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player" && other.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying)
            {
                //Debug.Log("Player EXIT Cone");
                m_Guard.SetBlackboardValue("PlayerInCone", false);
                //StartCoroutine(m_Guard.OutOfSightHysteresis());
            }
        }

        //private void OnTriggerStay(Collider other)
        //{
        //    if (other.tag == "Player" && other.transform.GetComponent<CharacterStateController>().thisCharacter == GMController.instance.isCharacterPlaying)
        //    {
        //        m_Guard.SetBlackboardValue("PlayerInCone", true);
        //    }
        //}

        public void UpdateRaycastParams()
        {
            
            //Debug.Log("Defined cone bounds");
            Vector3 bounds = m_Mesh.bounds.extents;
            raycastLength = bounds.z * 2f * transform.localScale.z;

            GetComponent<MakeObjInvisible>().MakeInvisible();

            max_theta_Angle = Mathf.Atan((bounds.x * transform.localScale.x) / raycastLength) * 180f / Mathf.PI;
            max_psi_Angle = Mathf.Atan((bounds.y * transform.localScale.y) / raycastLength) * 180f / Mathf.PI;

            //Debug.Log(max_theta_Angle + " - " + max_psi_Angle);

        }

    }
}
