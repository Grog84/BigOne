using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public abstract class Blackboard
    {

        public abstract int GetIntValue(string valueName);

        public abstract void SetIntValue(string valueName, int value);

    }
}
