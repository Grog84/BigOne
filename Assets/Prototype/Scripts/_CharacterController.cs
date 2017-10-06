using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterController : MonoBehaviour {

    [HideInInspector] public float m_MoveSpeedMultiplier;
    [HideInInspector] public float m_TurnAmount;
    [HideInInspector] public float m_ForwardAmount;

    [HideInInspector] public bool isClimbable;

    private StateController controller;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<StateController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
