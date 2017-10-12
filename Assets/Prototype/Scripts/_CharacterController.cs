using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class _CharacterController : MonoBehaviour {

    [HideInInspector] public float m_MoveSpeedMultiplier;
    [HideInInspector] public float m_TurnAmount;
    [HideInInspector] public float m_ForwardAmount;
    [HideInInspector] public float ray_length;

    [HideInInspector] public bool isInClimbArea;                   // The player is in the trigger area for Climbing
    [HideInInspector] public bool isClimbDirectionRight;           // The player is facing the climbable object
    [HideInInspector] public bool climbingBottom;
    [HideInInspector] public bool climbingTop;
    [HideInInspector] public bool startClimbAnimation;

    [HideInInspector] public bool isInPushArea;                    // The player is in the trigger area for Pushing
    [HideInInspector] public bool isPushDirectionRight;            // The player is facing the pushable object
    [HideInInspector] public bool isPushLimit;                     // The pushable object reach the limit point
    [HideInInspector] public bool canStep = true;

    [HideInInspector] public float charDepth;
    [HideInInspector] public float charSize;

    [HideInInspector] public Animator m_Animator;
    [HideInInspector] public Transform m_Camera;                   // A reference to the main camera in the scenes transform
    [HideInInspector] public Transform CharacterTansform;          // A reference to the character assigned to the state controller transform
    [HideInInspector] public Rigidbody m_Rigidbody;                // A reference to the rigidbody
    [HideInInspector] public CapsuleCollider m_Capsule;            // A reference to the capsule collider
    [HideInInspector] public CharacterController m_CharController;


    [HideInInspector] public GameObject climbCollider;
    [HideInInspector] public Transform  climbAnchorTop;
    [HideInInspector] public Transform  climbAnchorBottom;
    [HideInInspector] public Transform  endClimbAnchor;

    [HideInInspector] public float floorNoiseMultiplier;

    public CharacterStats m_CharStats;
    public LayerMask m_WalkNoiseLayerMask;


    [HideInInspector] public GameObject pushCollider;


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
        isInPushArea = false;
        ray_length = m_CharController.bounds.size.y / 2.0f + 0.1f;

    }
	
    void ActivateClimbingChoice()
    {
        if(isInClimbArea)
        {
            RaycastHit hit;

            if (Physics.Raycast(CharacterTansform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTansform.forward, out hit, m_CharStats.m_DistanceFromWallClimbing))
            {
                Debug.DrawRay(CharacterTansform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTansform.forward, Color.red);
               


                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Climbable"))
                {
                    isClimbDirectionRight = true;
                    Debug.Log("vedo");

                }
                else
                {
                    isClimbDirectionRight = false;
                }
            }
        }
    }

    void ActivatePushingChoice()
    {
        if (isInPushArea)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.forward, out hit, m_CharStats.m_DistanceFromPushableObject))
            {
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.Log("vedo");


                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Pushable"))
                {
                    isPushDirectionRight = true;
                }
                else
                {
                    isPushDirectionRight = false;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ladder_Bottom")
        {
            ActivateClimbingChoice();    
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            ActivatePushingChoice();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ladder_Bottom")
        {
            climbCollider = other.gameObject;
            isInClimbArea = true;
            climbingBottom = true;
            ActivateClimbingChoice();
           // Debug.Log("entro");
        }
        else if (other.tag == "Ladder_Top")
        {
            climbCollider = other.gameObject;
            isInClimbArea = true;
            climbingTop = true;
            Debug.Log("entro");
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            pushCollider = other.gameObject;
            isInPushArea = true;
            ActivatePushingChoice();
            Debug.Log("spingo");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ladder_Bottom")
        {
            climbCollider = null;
            isInClimbArea = false;
            climbingBottom = false;
           // Debug.Log("esco");
        }
        if (other.tag == "Ladder_Top")
        {
            climbCollider = null;
            isInClimbArea = false;
            climbingTop = false;
           // Debug.Log("esco");
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            pushCollider = null;
            isInPushArea = true;
            Debug.Log("spingo");
        }

    }

    private IEnumerator ReachPoint()
    {
        float climbTime = 1f;
        startClimbAnimation = false;

        m_CharController.enabled = false;
        CharacterTansform.DOMove(climbAnchorTop.position, climbTime);
        yield return new WaitForSeconds(climbTime);
        m_CharController.enabled = true;
        yield return null;
    }

    public IEnumerator MakeStep()
    {
        yield return new WaitForSeconds(1f);
        canStep = true;
    }

    void Update ()
    {
		if(startClimbAnimation)
        {
            StartCoroutine(ReachPoint());
        }

        if (!canStep)
        {
            StartCoroutine(MakeStep());
        }
	}

}
