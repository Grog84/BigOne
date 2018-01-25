using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{

    public class PedestrianAnimController : MonoBehaviour
    {

        Pedestrian m_Pedestrian;
        public float pedestrianAnimTick = 2f;
        public float pedestrianClimbAnimation = 5f;

        private void Awake()
        {
            m_Pedestrian = GetComponent<Pedestrian>();
        }

        IEnumerator AnimCO()
        {
            while (true)
            {
                m_Pedestrian.m_Animator.SetBool("Climbing", m_Pedestrian.m_Blackboard.GetBoolValue("PlayerIsClimbing"));
                if(m_Pedestrian.m_Blackboard.GetBoolValue("PlayerIsClimbing"))
                    yield return new WaitForSeconds(pedestrianClimbAnimation);
                else
                    yield return new WaitForSeconds(pedestrianAnimTick);
            }
        }
    }
}