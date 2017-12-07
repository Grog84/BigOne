using UnityEngine;
using Sirenix.OdinInspector;

namespace MissionManagerStuff
{
    public class QuestGiver:SerializedMonoBehaviour
    {
        public int missionIndex;
        public Mission myMission;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                myMission.available = true;               
            }
        }


    }
}

