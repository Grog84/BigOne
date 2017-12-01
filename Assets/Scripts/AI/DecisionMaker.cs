using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [System.Serializable]
    public abstract class DecisionMaker : ScriptableObject
    {
        [SerializeField]
        public Blackboard m_Blackboard;

        public abstract void MakeDecision();
    }
}
