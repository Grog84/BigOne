using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class StateTool : MonoBehaviour {

    public Guard m_Guard;
    public Transform playerTransform;

	// Use this for initialization
	void Start () {

        m_Guard = GetComponent<Guard>();
	}

}
