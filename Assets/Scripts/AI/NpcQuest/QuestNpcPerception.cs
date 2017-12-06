using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class QuestNpcPerception : MonoBehaviour {

    GameObject m_Npc;
    QuestNpc m_QuestGiver;
    Transform playerHead;
    public Transform origin;

    private void Awake()
    {
        m_Npc = transform.parent.gameObject;
        m_QuestGiver = m_Npc.GetComponent<QuestNpc>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            playerHead = other.GetComponent<_CharacterController>().playerHead;
            m_QuestGiver.lookAtTarget = playerHead;
            if (Physics.Raycast(origin.position, playerHead.position))
            {
                m_QuestGiver.SetBlackboardValue("playerSaw", true);

            }
            else
            {
                m_QuestGiver.SetBlackboardValue("playerSaw", false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_QuestGiver.SetBlackboardValue("playerSaw", false);
            m_QuestGiver.SetBlackboardValue("lookAtPlayer", false);
        }
    }
}
