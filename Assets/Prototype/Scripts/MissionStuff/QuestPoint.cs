using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;


namespace QuestManager
{

    public class QuestPoint : MonoBehaviour
    {
        public POINT m_Point;
        [ReadOnly]
        public Quest m_Quest;
        private BoxCollider m_boxCollider;
        // Use this for initialization
        void Start()
        {
            //ricevere informazioni della quest, e getcomponent del box collider
            m_boxCollider = GetComponent<BoxCollider>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Mother" || other.gameObject.name == "Boy")
            {
                if (m_Point == POINT.POINT_B)
                {
                    m_Quest.completed = true;
                }
            }
        }
    }
}