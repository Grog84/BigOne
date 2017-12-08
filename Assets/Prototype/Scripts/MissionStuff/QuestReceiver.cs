using UnityEngine;
using Sirenix.OdinInspector;

namespace MissionManagerStuff
{
    public class QuestReceiver: SerializedMonoBehaviour
    {
        [ReadOnly]
        public Mission myMission;
    

        public void AnalyzeQuestStatus(GameObject questObject)
        {

            if (questObject.GetComponent<QuestObject>().Picked == true)
            {
                if (questObject.GetComponent<QuestObject>().Bringed == true)
                {
                    myMission.completed = true;
                }
            }

        }


    }
}

