using UnityEngine;
using Sirenix.OdinInspector;

namespace QuestManager
{
    public class QuestReceiver: SerializedMonoBehaviour
    {
        [ReadOnly]
        public Quest myMission;
    

        public void AnalyzeQuestStatus(GameObject questObject)
        {

            //if (questObject.GetComponent<QuestObject>().Picked == true)
            //{
            //    if (questObject.GetComponent<QuestObject>().Bringed == true)
            //    {
            //        myMission.completed = true;
            //    }
            //}

        }


    }
}

