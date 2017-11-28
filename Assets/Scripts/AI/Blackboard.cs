using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public abstract class Blackboard
    {
        public AIAgent m_Agent;

        public abstract int GetIntValue(string valueName);

        public abstract void SetIntValue(string valueName, int value);

        public abstract bool GetBoolValue(string valueName);

        public abstract void SetBoolValue(string valueName, bool value);

        public abstract Vector3 GetVector3Value(string valueName);

        public abstract void SetVector3Value(string valueName, Vector3 value);

    }
}
