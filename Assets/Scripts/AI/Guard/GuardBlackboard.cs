using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class GuardBlackboard : Blackboard
    {
        GuardState guardState = GuardState.NORMAL;

        public override int GetIntValue(string valueName)
        {
            if (valueName == "GuardState")
            {
                return (int)guardState;
            }

            return -1;
        }

        public override void SetIntValue(string valueName, int value)
        {
            if (valueName == "GuardState")
            {
                guardState = (GuardState)value;
            }

        }

    }
}