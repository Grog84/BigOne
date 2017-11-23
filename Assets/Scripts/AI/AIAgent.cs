using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SaveGame;

namespace AI
{
    public abstract class AIAgent : MonoBehaviour
    {
        //Navigation
        public NavMeshAgent m_NavMeshAgent;

        // Animation
        public Animator m_Animator;

        // AI
        public Brain m_Brain;
        public Blackboard m_Blackboard;

    }
}

