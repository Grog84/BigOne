using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using DG.Tweening;
using StateMachine;
using AI;
using UnityEngine.UI;

public class EnemyRadar : MonoBehaviour
{

    [HideInInspector] public GameObject target;
    [HideInInspector] public Vector3 newTarget;

    //Animator m_PointerAnimator;

    public Transform enemyClose;
    public float colorTime;
    public Sprite normal;
    public Sprite curious;
    public Sprite alarmed;

    void Start ()
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
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = normal;
            //m_PointerAnimator.PlayTime(0f);
        }
        else if(target.GetComponent<Guard>().GetState == GuardState.CURIOUS)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.yellow, colorTime);
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = curious;
            //m_PointerAnimator.PlayTime(0.5f);
        }
        else if (target.GetComponent<Guard>().GetState == GuardState.ALARMED)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.red, colorTime);
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = alarmed;
            //m_PointerAnimator.PlayTime(1f);
        }
        else if (target.GetComponent<Guard>().GetState == GuardState.DISTRACTED)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.blue, colorTime);
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = curious;
            //m_PointerAnimator.PlayTime(0f);
        }
    } 

}
