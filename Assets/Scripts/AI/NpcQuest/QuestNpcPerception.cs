using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using AI;

public class QuestNpcPerception : MonoBehaviour {

    GameObject m_Npc;
    QuestNpc m_QuestGiver;
    private Transform target;
    private Transform raycastTarget;
    public Transform origin;

    public LayerMask visionLayerMask;

    private void Awake()
    {
        m_Npc = transform.parent.gameObject;
        m_QuestGiver = m_Npc.GetComponent<QuestNpc>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            target = other.transform;
            raycastTarget = target.FindDeepChildByTag("LookAtPositionCentral");
            m_Npc.GetComponent<Animator>().SetTrigger("PlayerSaw");
            m_QuestGiver.lookAtTarget = target;
        }

    }


    private void OnTriggerStay(Collider other)
    { 
        if(other.tag == "Player")
        {
            Ray ray = new Ray (origin.position, (raycastTarget.position - origin.position).normalized);
            RaycastHit hit = new RaycastHit();
            bool hasHit = Physics.Raycast(ray,out hit, Mathf.Infinity, visionLayerMask);
            Debug.Log(hit.transform.gameObject.name);
            if (Physics.Raycast(ray ,Mathf.Infinity,visionLayerMask))
            {
                Debug.DrawRay(origin.position, (raycastTarget.position - origin.position).normalized);
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
