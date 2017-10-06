using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterController : MonoBehaviour {

    [HideInInspector] public float m_MoveSpeedMultiplier;
    [HideInInspector] public float m_TurnAmount;
    [HideInInspector] public float m_ForwardAmount;
    [HideInInspector] public float ray_length;

    [HideInInspector] public bool isClimbable;

    [HideInInspector] public Animator m_Animator;
    [HideInInspector] public Transform m_Camera;                   // A reference to the main camera in the scenes transform
    [HideInInspector] public Transform CharacterTansform;          // A reference to the character assigned to the state controller transform
    [HideInInspector] public Rigidbody m_Rigidbody;                // A reference to the rigidbody
    [HideInInspector] public CapsuleCollider m_Capsule;            // A reference to the capsule collider
    [HideInInspector] public CharacterController m_CharController; // A reference to the capsule collider

    private StateController controller;

    private void Awake()
    {
        CharacterTansform = GetComponent<Transform>();          // A reference to the character assigned to the state controller transform
        m_Animator = GetComponent<Animator>();
        m_CharController = GetComponent<CharacterController>();
        GameObject m_CameraObj = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        m_Camera = m_CameraObj.transform;
    }

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<StateController>();
        isClimbable = false;
        ray_length = m_CharController.bounds.size.y / 2.0f + 0.1f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
