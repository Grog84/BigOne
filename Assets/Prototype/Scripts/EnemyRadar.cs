using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using DG.Tweening;
using StateMachine;
using AI;

public class EnemyRadar : MonoBehaviour
{

    [HideInInspector] public float pos;
    [HideInInspector] public GameObject target;
    [HideInInspector] public Vector3 newTarget;

    public Transform enemyClose;
    public float colorTime;


    void Awake ()
    {
        transform.position = transform.parent.position + Vector3.up * transform.parent.GetComponent<_CharacterController>().m_CharController.bounds.size.y / 2.0f + new Vector3(0,pos,0);    
    }

    private void Update()
    {
        
        newTarget = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        
        transform.DOLookAt(newTarget, 0.1f);

        if(target.GetComponent<Guard>().GetState == GuardState.NORMAL)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor (Color.red, colorTime);
        }
        else if(target.GetComponent<Guard>().GetState == GuardState.CURIOUS)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.yellow, colorTime);
        }
        else if (target.GetComponent<Guard>().GetState == GuardState.ALARMED)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.red, colorTime);
        }
        else if (target.GetComponent<Guard>().GetState == GuardState.DISTRACTED)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.blue, colorTime);
        }
    } 

}
