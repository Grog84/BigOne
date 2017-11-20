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
        NavMeshAgent m_NavMeshAgent;

        // Animation
        Animator m_Animator;

    }
}

