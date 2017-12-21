using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using DG.Tweening;
using StateMachine;
using AI;

public class EnemyRadar : MonoBehaviour
{

    [HideInInspector] public GameObject target;
    [HideInInspector] public Vector3 newTarget;

    //Animator m_PointerAnimator;

    public Transform enemyClose;
    public float colorTime;


    void Awake ()
    {
        transform.position = transform.parent.position + Vector3.up * transform.parent.GetComponent<_CharacterController>().m_CharController.bounds.size.y / 2.0f;
        //m_PointerAnimator = GetComponentInChildren<Animator>();
        //m_PointerAnimator.speed = 0;
    }

    private void Update()
    {
        
        newTarget = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        
        transform.DOLookAt(newTarget, 0.1f);

        if(target.GetComponent<Guard>().GetState == GuardState.NORMAL)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor (Color.white, colorTime);
            //m_PointerAnimator.PlayTime(0f);
        }
        else if(target.GetComponent<Guard>().GetState == GuardState.CURIOUS)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.yellow, colorTime);
            //m_PointerAnimator.PlayTime(0.5f);
        }
        else if (target.GetComponent<Guard>().GetState == GuardState.ALARMED)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.red, colorTime);
            //m_PointerAnimator.PlayTime(1f);
        }
        else if (target.GetComponent<Guard>().GetState == GuardState.DISTRACTED)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.blue, colorTime);
            //m_PointerAnimator.PlayTime(0f);
        }
    } 

}
