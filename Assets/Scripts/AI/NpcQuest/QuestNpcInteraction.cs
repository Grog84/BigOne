using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class QuestNpcInteraction : MonoBehaviour {

    GameObject m_Npc;
    QuestNpc m_QuestNpc;
    

    private void Awake()
    {
        m_Npc = transform.parent.gameObject;
        m_QuestNpc = m_Npc.GetComponent<QuestNpc>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
           if(Input.GetButtonDown("Interact") && m_QuestNpc.canInteract)
           {
                other.GetComponent<_CharacterController>().hasInteractedWithNPC = true;
                m_QuestNpc.StopWaving();
                m_QuestNpc.m_Blackboard.SetBoolValue("playerInteracted", true);
                m_QuestNpc.canInteract = false;
           }
        }
    }

    
}
