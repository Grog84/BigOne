using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "AI/GuardBlackboard")]
    [System.Serializable]
    public class GuardBlackboard : Blackboard
    {
        GuardState guardState = GuardState.NORMAL;
        bool isPlayerInSight = false;
        bool randomPick = false;
        bool otherAlarmed = false;
        bool isCheckingNavPoint = false;
        bool isCheckingNavPointCoroutineRunning = false;
        int currentNavPoint = 0;
        int numberOfNavPoints;
        float navPointTimer = 0;
        Vector3 lastPercievedPosition;
        Vector3 resetPlayerPosition = new Vector3(1000, 1000, 1000);

        public override int GetIntValue(string valueName)
        {
            switch (valueName)
            {
                case "GuardState":
                    return (int)guardState;
                case "CurrentNavPoint":
                    return currentNavPoint;
                case "NumberOfNavPoints":
                    return numberOfNavPoints;
                default:
                    return -1;
            }
    
        }

        public override void SetIntValue(string valueName, int value)
        {
            switch (valueName)
            {
                case "GuardState":
                    guardState = (GuardState)value;
                    break;
                case "CurrentNavPoint":
                    currentNavPoint = value;
                    break;
                case "NumberOfNavPoints":
                    numberOfNavPoints = value;
                    break;
                default:
                    break;
            }
        }

        public override float GetFloatValue(string valueName)
        {
            switch (valueName)
            {
                case "NavPointTimer":
                    return navPointTimer;
                default:
                    return -1;
            }
        }

        public override void SetFloatValue(string valueName, float value)
        {
            switch (valueName)
            {
                case "NavPointTimer":
                    navPointTimer = value;
                    break;
                default:
                    break;
            }
        }

        public override bool GetBoolValue(string valueName)
        {
            switch (valueName)
            {
                case "PlayerInSight":
                    return isPlayerInSight;
                case "RandomPick":
                    return randomPick;
                case "OtherAlarmed":
                    return otherAlarmed;
                case "CheckingNavPoint":
                    return isCheckingNavPoint;
                case "WaitingCoroutineRunning":
                    return isCheckingNavPointCoroutineRunning;
                default:
                    Debug.Log("Default");
                    return false;
            }
        }

        public override void SetBoolValue(string valueName, bool value)
        {
            switch (valueName)
            {
                case "PlayerInSight":
                    isPlayerInSight = value;
                    break;
                case "RandomPick":
                    randomPick = value;
                    break;
                case "OtherAlarmed":
                    otherAlarmed = value;
                    break;
                case "CheckingNavPoint":
                    isCheckingNavPoint = value;
                    break;
                case "WaitingCoroutineRunning":
                    isCheckingNavPointCoroutineRunning = value;
                    break;
                default:
                    break;
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