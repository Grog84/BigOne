using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class QuestNpcPerception : MonoBehaviour {

    GameObject m_Npc;
    QuestNpc m_QuestGiver;
    public Transform playerHead;
    public Transform origin;

    public LayerMask visionLayerMask;

    private void Awake()
    {
        m_Npc = transform.parent.gameObject;
        m_QuestGiver = m_Npc.GetComponent<QuestNpc>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerHead = other.GetComponent<_CharacterController>().playerHead;
        m_QuestGiver.lookAtTarget = playerHead;
        m_Npc.GetComponent<Animator>().SetTrigger("PlayerSaw");

    }


    private void OnTriggerStay(Collider other)
    { 
        if(other.tag == "Player")
        {
            Ray ray = new Ray (origin.position,playerHead.position);
            
            if (Physics.Raycast(ray ,Mathf.Infinity,visionLayerMask))
            {     
                Debug.DrawLine(origin.position, playerHead.position, Color.red);
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
