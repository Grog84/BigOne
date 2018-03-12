using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class QuestNpcPerception : MonoBehaviour {

    GameObject m_Npc;
    NpcQuest npcQuest;
    private Transform target;
    private Transform raycastTarget;
    public Transform origin;

    public LayerMask visionLayerMask;

    private void Awake()
    {
        m_Npc = transform.parent.gameObject;
        npcQuest = m_Npc.GetComponent<NpcQuest>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            target = other.transform;
            npcQuest.playerSaw = true;
            raycastTarget = target.FindDeepChildByTag("LookAtPositionCentral");
            m_Npc.GetComponent<Animator>().SetBool("PlayerSaw",true);
        }

    }


    private void OnTriggerStay(Collider other)
    { 
        if(other.tag == "Player")
        {
            Ray ray = new Ray (origin.position, (raycastTarget.position - origin.position).normalized);
            RaycastHit hit = new RaycastHit();
            bool hasHit = Physics.Raycast(ray,out hit, Mathf.Infinity, visionLayerMask);

            if (Physics.Raycast(ray ,Mathf.Infinity,visionLayerMask))
            {
                Debug.DrawRay(origin.position, (raycastTarget.position - origin.position).normalized);
                //npcQuest.playerSaw = true;
                //npcQuest.m_Animator.SetBool("PlayerSaw", true);
            }                  
            else
            {
                //npcQuest.playerSaw = false;
                npcQuest.m_Animator.SetBool("PlayerSaw", false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            npcQuest.playerSaw = false;
            npcQuest.m_Animator.SetBool("PlayerSaw", false);
        }
    }
}
