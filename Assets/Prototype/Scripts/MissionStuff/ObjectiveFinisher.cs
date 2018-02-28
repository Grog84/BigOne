using Sirenix.OdinInspector;
using UnityEngine;
using AI;

namespace QuestManager
{
    public class ObjectiveFinisher : SerializedMonoBehaviour
    {
        public Quest myMission;
        private QuestManager QM;
        private void Awake()
        {
           QM= GameObject.FindObjectOfType<QuestManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (GetComponent<QuestNpc>() == null)
            {
                if (other.gameObject.tag == "Player")
                {
                    QM.ActivateNextObjective();
                }
            }
        }

    }
}

