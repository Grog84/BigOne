using UnityEngine;
using Sirenix.OdinInspector;

namespace QuestManager
{
    public class QuestGiver:SerializedMonoBehaviour
    {
        public int missionIndex;
       
        public Quest myMission;
        

        private void Update()
        {
            //Ignore... for research purpose only
            //if(Input.GetKeyDown(KeyCode.Space))
            //    {
            //    myMission.available = true;
            //    myMission.completed = true;
            //}

        }
        public void AnalyzeQuestStatus(GameObject questObject)
        {

            

        }
    }
}

