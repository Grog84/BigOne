using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class QuestNpcInteraction : MonoBehaviour {

    GameObject m_Npc;
    QuestNpc m_QuestGiver;
    

    private void Awake()
    {
        m_Npc = transform.parent.gameObject;
        m_QuestGiver = m_Npc.GetComponent<QuestNpc>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
           if(Input.GetButtonDown("Interact") && m_QuestGiver.canInteract)
           {
                m_QuestGiver.m_Blackboard.SetBoolValue("playerInteracted", true);
                m_QuestGiver.canInteract = false;
           }
        }
    }

    
}
