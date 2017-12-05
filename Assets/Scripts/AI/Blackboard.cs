using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [System.Serializable]
    public abstract class Blackboard: System.Object
    {
        public AIAgent m_Agent;

        public abstract int GetIntValue(string valueName);

        public abstract void SetIntValue(string valueName, int value);

        public abstract float GetFloatValue(string valueName);

        public abstract void SetFloatValue(string valueName, float value);

        public abstract bool GetBoolValue(string valueName);

        public abstract void SetBoolValue(string valueName, bool value);

        public abstract Vector3 GetVector3Value(string valueName);

        public abstract void SetVector3Value(string valueName, Vector3 value);

        public override string ToString()
        {
            string printOut;
            if (m_Agent != null)
                printOut = m_Agent.ToString() + " Blackboard";
            else
                printOut = base.ToString();
            return printOut;
        }

    }
}
