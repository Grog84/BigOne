using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    public State currentState;
    public MyAgentStats agentStats;        // more controllers just for this issue?
    public CharacterStats characterStats;  // more controllers just for this issue?
    public CharacterObj characterObj;
    public Transform eyes;
    public List<Transform> wayPointList;
    public State remainState;

    [HideInInspector] public _CharacterController m_CharacterController;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool isActive = true;

	// Use this for initialization
	void Awake () {

        navMeshAgent = GetComponent<NavMeshAgent>();

        characterObj.CharacterTansform = GetComponent<Transform>();          // A reference to the character assigned to the state controller transform
        characterObj.m_Rigidbody = GetComponent<Rigidbody>();                // A reference to the rigidbody
        characterObj.m_Capsule = GetComponent<CapsuleCollider>();            // A reference to the capsule collider
        characterObj.m_Animator = GetComponent<Animator>();

        GameObject m_CameraObj = GameObject.FindGameObjectsWithTag("Respawn")[0];
        characterObj.m_Camera = m_CameraObj.transform;

    }
	
	// Update is called once per frame
	void Update () {

        if (!isActive)
            return;
        currentState.UpdateState(this);

	}

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmosColor;
            Gizmos.DrawWireSphere(eyes.position, agentStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState.OnExitState(this);
            currentState = nextState;
            currentState.OnEnterState(this);
            OnExitState();
        }
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

}
