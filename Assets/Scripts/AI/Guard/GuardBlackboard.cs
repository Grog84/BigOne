using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class GuardBlackboard : Blackboard
    {
        GuardState guardState = GuardState.NORMAL;
        bool isPlayerInSight = false;

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

        public override bool GetBoolValue(string valueName)
        {
            if (valueName == "PlayerInSight")
            {
                return isPlayerInSight;
            }

            return false;
        }

        public override void SetBoolValue(string valueName, bool value)
        {
            if (valueName == "PlayerInSight")
            {
                isPlayerInSight = value;
            }

        }

    }
}