using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public abstract class DecisionMaker : ScriptableObject
    {
        public Blackboard m_Blackboard;

        public abstract void MakeDecision();
    }
}
