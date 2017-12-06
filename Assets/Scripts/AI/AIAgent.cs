using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SaveGame;

namespace AI
{
    [System.Serializable]
    public abstract class AIAgent : MonoBehaviour
    {
        //Navigation
        [HideInInspector] public NavMeshAgent m_NavMeshAgent;

        // Animation
        [HideInInspector] public Animator m_Animator;

        // AI
        [HideInInspector] public Brain m_Brain;
        [HideInInspector] public Blackboard m_Blackboard;

        public override string ToString()
        {
            return gameObject.name;
        }

        public abstract void UpdateNavPoint();
        public abstract void ReachNavPoint();

    }
}

