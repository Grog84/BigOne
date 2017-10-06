using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterController : MonoBehaviour {

    [HideInInspector] public float m_MoveSpeedMultiplier;
    [HideInInspector] public float m_TurnAmount;
    [HideInInspector] public float m_ForwardAmount;
    [HideInInspector] public float ray_length;

    [HideInInspector] public bool isInClimbArea;                   // The player is in the trigger area
    [HideInInspector] public bool isClimbDirectionRight;           // The player is facing the climbable object
    [HideInInspector] public bool climbingBottom;
    [HideInInspector] public bool climbingTop;

    [HideInInspector] public float charDepth;
    [HideInInspector] public float charSize;

    [HideInInspector] public Animator m_Animator;
    [HideInInspector] public Transform m_Camera;                   // A reference to the main camera in the scenes transform
    [HideInInspector] public Transform CharacterTansform;          // A reference to the character assigned to the state controller transform
    [HideInInspector] public Rigidbody m_Rigidbody;                // A reference to the rigidbody
    [HideInInspector] public CapsuleCollider m_Capsule;            // A reference to the capsule collider
    [HideInInspector] public CharacterController m_CharController; // A reference to the capsule collider
                      public CharacterStats m_CharStats;

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
        isInClimbArea = false;
        ray_length = m_CharController.bounds.size.y / 2.0f + 0.1f;

    }
	
    void ActivateClimbingChoice()
    {
        if(isInClimbArea)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.forward, out hit, m_CharStats.m_DistanceFromWallClimbing))
            {
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.Log("vedo");


                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Climbable"))
                {
                    isClimbDirectionRight = true;
                   

                }
                else
                {
                    isClimbDirectionRight = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ladder_Bottom")
        {
            isInClimbArea = true;
            climbingBottom = true;
            Debug.Log("entro");
        }
        else if (other.tag == "Ladder_Top")
        {
            isInClimbArea = true;
            climbingTop = true;
            Debug.Log("entro");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ladder_Bottom")
        {
            isInClimbArea = false;
            climbingBottom = false;
            Debug.Log("esco");
        }
        if (other.tag == "Ladder_Top")
        {
            isInClimbArea = false;
            climbingTop = false;
            Debug.Log("esco");
        }

    }
    // Update is called once per frame
    void Update () {
		
	}

}
