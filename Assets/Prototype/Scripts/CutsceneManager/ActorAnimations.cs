using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActorAnimations : MonoBehaviour {

    Animator m_Animator;
    NavMeshAgent m_NavMeshAgent;

    [HideInInspector] public float m_TurnAmount;

    void Start ()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        Vector3 move = m_NavMeshAgent.velocity;
        if (move.magnitude > 1f) move.Normalize();
        move = transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, Vector3.down);
        m_TurnAmount = Mathf.Atan2(move.x, move.z);
        float m_ForwardAmount = move.z;

        m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
    }
}
