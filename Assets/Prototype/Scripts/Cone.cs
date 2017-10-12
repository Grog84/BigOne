using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {

    public ConeStats coneStats;
    public bool isDebug;

    private _AgentController m_AgentController;

    private void Awake()
    {
        m_AgentController = GetComponentInParent<_AgentController>();
    }

    void Start() {

        transform.localScale.Set(coneStats.scaleX, coneStats.scaleY, coneStats.scaleZ);
    }

    private void Update()
    {
        if (isDebug)
        {
            transform.localScale.Set(coneStats.scaleX, coneStats.scaleY, coneStats.scaleZ);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_AgentController.isPlayerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_AgentController.isPlayerInSight = false;
        }
    }

}
