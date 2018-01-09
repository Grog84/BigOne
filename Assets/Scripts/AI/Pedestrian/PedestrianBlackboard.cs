using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "AI/PedestrianBlackboard")]
    [System.Serializable]
    public class PedestrianBlackboard: Blackboard
    {
        bool isPlayerInSight;

        public override int GetIntValue(string valueName)
        {
            switch (valueName)
            {
                //case "GuardState":
                //    return (int)guardState;
                //case "CurrentNavPoint":
                //    return currentNavPoint;
                //case "NumberOfNavPoints":
                //    return numberOfNavPoints;
                default:
                    return -1;
            }
    
        }

        public override void SetIntValue(string valueName, int value)
        {
            switch (valueName)
            {
                //case "GuardState":
                //    guardState = (GuardState)value;
                //    break;
                //case "CurrentNavPoint":
                //    currentNavPoint = value;
                //    break;
                //case "NumberOfNavPoints":
                //    numberOfNavPoints = value;
                //    break;
                default:
                    break;
            }
        }

        public override float GetFloatValue(string valueName)
        {
            switch (valueName)
            {
                //case "NavPointTimer":
                //    return navPointTimer;
                default:
                    return -1;
            }
        }

        public override void SetFloatValue(string valueName, float value)
        {
            switch (valueName)
            {
                //case "NavPointTimer":
                //    navPointTimer = value;
                //    break;
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
                default:
                    break;
            }     
        }

        public override Vector3 GetVector3Value(string valueName)
        {
            switch (valueName)
            {
                //case "LastPercievedPosition":
                //    return lastPercievedPosition;
                //case "NavigationPosition":
                //    return navigationPosition;
                default:
                    break;
            }

            return Vector3.zero;
        }

        public override void SetVector3Value(string valueName, Vector3 value)
        {
            switch (valueName)
            {
                //case "LastPercievedPosition":
                //    lastPercievedPosition = value;
                //    break;
                //case "NavigationPosition":
                //    navigationPosition = value;
                //    break;
                default:
                    break;
            }
            
        }
    }
}