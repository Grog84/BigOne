using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "AI/NpcBlackboard")]
    [System.Serializable]
    public class QuestNpcBlackboard : Blackboard
    {
        bool isLookingAtPlayer = false;
        bool playerSaw = false;

        public override int GetIntValue(string valueName)
        {
            switch (valueName)
            {
               
                default:
                    return -1;
            }
    
        }

        public override void SetIntValue(string valueName, int value)
        {
            switch (valueName)
            {
                
                default:
                    break;
            }
        }

        public override float GetFloatValue(string valueName)
        {
            switch (valueName)
            {
               
                default:
                    return -1;
            }
        }

        public override void SetFloatValue(string valueName, float value)
        {
            switch (valueName)
            {
                
                default:
                    break;
            }
        }

        public override bool GetBoolValue(string valueName)
        {
            switch (valueName)
            {
                case "playerSaw":
                    return playerSaw;
                case "lookAtPlayer":
                    return isLookingAtPlayer;
                default:
                    Debug.Log("Default");
                    return false;
            }
        }

        public override void SetBoolValue(string valueName, bool value)
        {
            switch (valueName)
            {
                case "playerSaw":
                    playerSaw = value;
                    break;
                case "lookAtPlayer":
                    isLookingAtPlayer = value;
                    break;
                default:
                    break;
            }     
        }

        public override Vector3 GetVector3Value(string valueName)
        {
            return Vector3.zero;
        }

        public override void SetVector3Value(string valueName, Vector3 value)
        {

        }   
    }
}