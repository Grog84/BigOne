using UnityEngine;
using Sirenix.OdinInspector;

namespace MissionManagerStuff
{
    public class QuestGiver:SerializedMonoBehaviour
    {
        public int missionIndex;
        [ReadOnly]
        public Mission myMission;

        private void Update()
        {
            //Ignore... for research purpose only
            //if(Input.GetKeyDown(KeyCode.Space))
            //    {
            //    myMission.available = true;
            //    myMission.completed = true;
            //}
        }


    }
}

