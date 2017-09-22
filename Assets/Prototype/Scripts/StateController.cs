using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public List<Transform> wayPointList;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public int nextWayPoint;

    private bool isActive;

	// Use this for initialization
	void Awake () {

        navMeshAgent = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!isActive)
            return;
        currentState.UpdateState(this);

	}

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmosColor;
            Gizmos.DrawSphere(eyes.position, 0.2f);
        }
    }
}
