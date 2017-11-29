using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class GuardBlackboard : Blackboard
    {
        GuardState guardState = GuardState.NORMAL;
        bool isPlayerInSight = false;
        bool randomPick = false;
        bool otherAlarmed = false;
        Vector3 lastPercievedPosition;
        Vector3 resetPlayerPosition = new Vector3(1000, 1000, 1000);

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

            if(valueName == "RandomValue")
            {
                return randomPick;
            }

            if(valueName == "OtherAllarmed")
            {
                return otherAlarmed;
            }
            return false;
        }

        public override void SetBoolValue(string valueName, bool value)
        {
            if (valueName == "PlayerInSight")
            {
                isPlayerInSight = value;
            }

            if (valueName == "RandomValue")
            {
                 randomPick = value;
            }

            if(valueName == "OtherAllarmed")
            {
                otherAlarmed = value;
            }
        }

        public override Vector3 GetVector3Value(string valueName)
        {
            if(valueName == "LastPercievedPosition")
            {
                return lastPercievedPosition;
            }

            return resetPlayerPosition;
        }

        public override void SetVector3Value(string valueName, Vector3 value)
        {
            if(valueName == "LastPercievedPosition")
            {
                lastPercievedPosition = value;
            }
        }
    }
}