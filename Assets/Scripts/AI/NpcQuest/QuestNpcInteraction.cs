using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class QuestNpcInteraction : MonoBehaviour {

    GameObject m_Npc;
    NpcQuest m_QuestNpc;
    

    private void Awake()
    {
        m_Npc = transform.parent.gameObject;
        m_QuestNpc = m_Npc.GetComponent<NpcQuest>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
           if(Input.GetButtonDown("Interact") && m_QuestNpc.canInteract)
           {
                other.GetComponent<_CharacterController>().hasInteractedWithNPC = true;
                //m_QuestNpc.StopWaving();
                m_QuestNpc.canInteract = false;

                //if(m_Npc.GetComponent<NpcQuestIcons>().isActive)
                //{
                //    m_QuestNpc.m_Animator.SetTrigger("isGivingQuest");
                //    m_QuestNpc.StopWaving();

                //}
                //else if (!m_Npc.GetComponent<NpcQuestIcons>().isActive)
                //{
                //    m_QuestNpc.m_Animator.SetTrigger("isNegative");
                //    m_QuestNpc.StopWaving();

                //}
            }
        }
    }

    
}
