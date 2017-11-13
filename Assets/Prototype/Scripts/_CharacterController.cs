using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Character
{
    public class _CharacterController : MonoBehaviour
    {

        [HideInInspector] public float m_MoveSpeedMultiplier;
        [HideInInspector] public float m_TurnAmount;                   // Unutilized for the moment
        [HideInInspector] public float m_ForwardAmount;
        [HideInInspector] public float ray_length;
        //
        // CLIMB VARIABLES
        [HideInInspector] public bool isInClimbArea;                   // The player is in the trigger area for Climbing
        [HideInInspector] public bool isClimbDirectionRight;           // The player is facing the climbable object
        [HideInInspector] public bool climbingBottom;                  // The player is in the Bottom Trigger
        [HideInInspector] public bool climbingTop;                     // The player is in the Top Trigger
        [HideInInspector] public bool startClimbAnimationTop;          // Starts the descend from top
        [HideInInspector] public bool startClimbAnimationBottom;       // Starts the climb from bottom
        [HideInInspector] public bool startClimbAnimationEnd;          // Starts the EndClimb courutine
        [HideInInspector] public bool startClimbEnd;                   // Indicates if the EndClimb coroutine is finished
        [HideInInspector] public bool useEndClimbIk;
        [HideInInspector] public float ikWeight = 1;
        [HideInInspector] public bool secureFall;
        //
        // PUSH VARIABLES
        [HideInInspector] public bool isInPushArea;                    // The player is in the trigger area for Pushing
        [HideInInspector] public bool isPushDirectionRight;            // The player is facing the pushable object
        [HideInInspector] public bool isPushLimit;                     // Detect push limits like obstacles
        [HideInInspector] public bool isPushing;                       // Define the start push actions
        [HideInInspector] public bool isExitPush;                      // Indicates if the DetachFormPushable coroutine is finished
        //
        // DOORS & ITEMS VARIABLES
        [HideInInspector] public bool isInDoorArea;                    // Detect if the player is in the Door trigger area
        [HideInInspector] public bool isDoorDirectionRight;            // Detect if the player is looking toward the door
        [HideInInspector] public bool isInKeyArea;                     // Detect if the player is in the key object interactable area
        [HideInInspector] public bool startDoorAction;                 // Starts the DoorInteraction courutine
        [HideInInspector] public bool startItemAnimation;              // Starts the item collection courutine
        [HideInInspector] public bool isEndDoorAction;                 // Indicates if the DoorInteraction coroutine is finished
        [HideInInspector] public bool isDoorOpen;                      // Indicates if the door has to be opended or closed in the RotateDoor coroutine
        [HideInInspector] public bool isDoorRotate;                    // Indicates if the RotateDoor coroutine is finished
        [HideInInspector] public bool isEndAnim = false;               // Indicates if the player playing the door animation
        //
        [HideInInspector] public bool canStep = true;
        [HideInInspector] public float m_WalkSoundrange_sq;            // squared value
        [HideInInspector] public float floorNoiseMultiplier;

        [HideInInspector] public float charDepth;
        [HideInInspector] public float charSize;
        // COMPONENTS REFERENCES
        [HideInInspector] public Animator m_Animator;
        [HideInInspector] public Transform m_Camera;                   // A reference to the main camera in the scenes transform
        [HideInInspector] public Transform CharacterTransform;         // A reference to the character assigned to the state controller transform
        [HideInInspector] public Rigidbody m_Rigidbody;                // A reference to the rigidbody
        [HideInInspector] public CharacterController m_CharController; // A reference to the Character controller component

        // COLIDERS REFERENCES
        [HideInInspector] public GameObject climbCollider;
        [HideInInspector] public Transform climbAnchorTop;
        [HideInInspector] public Transform climbAnchorBottom;
        [HideInInspector] public Transform endClimbAnchor;

        [HideInInspector] public GameObject doorObject;
        [HideInInspector] public GameObject doorCollider;
        [HideInInspector] public GameObject KeyCollider;

        [HideInInspector] public GameObject pushObject;
        [HideInInspector] public GameObject pushCollider;
        //
        [HideInInspector] public bool isDefeated = false;

        [HideInInspector] public FootstepsEmitter footStepsEmitter;
        [HideInInspector] public float walkStatusRange = 1f;

        public CharacterStats m_CharStats;
        public LayerMask m_WalkNoiseLayerMask;
        public List<GameObject> Keychain;                               // List of all the key items collected by the player

        private bool oneStepCoroutineController = true;                 // used to make sure only one step coroutine is runnin at a given time


        private void Awake()
        {
            CharacterTransform = GetComponent<Transform>();          // A reference to the character assigned to the state controller transform
            m_Animator = GetComponent<Animator>();
            m_CharController = GetComponent<CharacterController>();
            GameObject m_CameraObj = GameObject.FindGameObjectsWithTag("MainCamera")[0];
            m_Camera = m_CameraObj.transform;
            footStepsEmitter = GetComponent<FootstepsEmitter>();
        }

        // Use this for initialization
        void Start()
        {
            isInClimbArea = false;
            isInPushArea = false;
            ray_length = m_CharController.bounds.size.y / 2.0f + 0.1f;

        }
        #region Raycast Check

        void ActivateDoors()
        {
            RaycastHit hit;
            Debug.DrawRay(CharacterTransform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTransform.forward, Color.red);

            if (isInDoorArea)
            {
                if (Physics.Raycast(CharacterTransform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTransform.forward, out hit, m_CharStats.m_DistanceFromDoor))
                {

                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Doors") && hit.transform == doorCollider.transform.parent.FindDeepChild("DoorBody"))
                    {
                        isDoorDirectionRight = true;
                    }
                    else
                    {
                        isDoorDirectionRight = false;
                    }
                }
                else
                {
                    isDoorDirectionRight = false;
                }
            }
        }

        void ActivateClimbingChoice()
        {
            if (isInClimbArea)
            {
                RaycastHit hit;

                if (Physics.Raycast(CharacterTransform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTransform.forward, out hit, m_CharStats.m_DistanceFromWallClimbing))
                {
                    Debug.DrawRay(CharacterTransform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTransform.forward, Color.red);



                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Climbable"))
                    {
                        isClimbDirectionRight = true;

                    }
                    else
                    {
                        isClimbDirectionRight = false;
                    }
                }
                else
                {
                    isClimbDirectionRight = false;
                }
            }
        }

        void ActivatePushingChoice()
        {
            if (isInPushArea)
            {
                RaycastHit hit;

                    // Debug.DrawRay(CharacterTransform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTransform.forward, Color.red);
                if (Physics.Raycast(CharacterTransform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTransform.forward, out hit, m_CharStats.m_DistanceFromPushableObject))
                {
                     //Debug.Log(hit.transform == pushCollider.transform.parent);


                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Pushable") && hit.transform == pushCollider.transform.parent)
                    {
                        isPushDirectionRight = true;
                    }
                    else
                    {
                        isPushDirectionRight = false;
                    }
                }
                else
                {
                    isPushDirectionRight = false;
                }

            }
        }

        #endregion

        #region Triggers

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Ladder_Bottom")
            {
                climbingBottom = true;
                ActivateClimbingChoice();
            }
            if (other.tag == "Ladder_Top")
            {
                climbingTop = true;
                ActivateClimbingChoice();
            }
            if (other.tag == "PushTrigger" && Vector3.Angle(CharacterTransform.forward, other.transform.forward) < 45)
            {
                pushCollider = other.gameObject;
                isInPushArea = true;
                ActivatePushingChoice();
            }
            else if (other.tag == "PushTrigger" && Vector3.Angle(CharacterTransform.forward, other.transform.forward) > 45)
            {
                ActivatePushingChoice();
            }
            if (other.tag == "UnlockedDoor" || other.tag == "LockedDoor")
            {
                ActivateDoors();
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Ladder_Bottom")
            {
                climbCollider = other.gameObject;
                isInClimbArea = true;
                climbingBottom = true;
            }
            else if (other.tag == "Ladder_Top")
            {
                climbCollider = other.gameObject;
                isInClimbArea = true;
                climbingTop = true;
            }
            if (other.tag == "PushTrigger" && Vector3.Angle(CharacterTransform.forward, other.transform.forward) < 45)
            {
                pushCollider = other.gameObject;
                isInPushArea = true;
            }
            if (other.tag == "UnlockedDoor" || other.tag == "LockedDoor")
            {
                doorCollider = other.gameObject;
                isInDoorArea = true;
            }
            if (other.tag == "Key")
            {
                KeyCollider = other.gameObject;
                isInKeyArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Ladder_Bottom")
            {
                climbCollider = null;
                isInClimbArea = false;
                climbingBottom = false;
                isClimbDirectionRight = false;
            }
            if (other.tag == "Ladder_Top")
            {
                climbCollider = null;
                isInClimbArea = false;
                climbingTop = false;
                isClimbDirectionRight = false;
            }
            if (other.tag == "PushTrigger" && Vector3.Angle(CharacterTransform.forward, other.transform.forward) > 45)
            {
                pushCollider = null;
                isInPushArea = false;
                isPushDirectionRight = false;
            }
            if (other.tag == "UnlockedDoor" || other.tag == "LockedDoor")
            {
                doorCollider = null;
                isInDoorArea = false;
                isDoorDirectionRight = false;
            }
            if (other.tag == "Key")
            {
                KeyCollider = null;
                isInKeyArea = false;
            }

        }

        #endregion

        private void UpdateSoundRange()  // This could be improved by updating only the data necessary
        {
            m_WalkSoundrange_sq = walkStatusRange * walkStatusRange * m_ForwardAmount;
        }

        #region Climb Coroutine

        public void EndClimbing()
        {
            //StartCoroutine(ReachPointEnd());
            useEndClimbIk = false;
            ikWeight = 1;
        }

        private IEnumerator ReachPointEnd()
        {
            useEndClimbIk = true;
            startClimbAnimationEnd = false;
            float climbTime = 2f;
            Vector3 difPos = endClimbAnchor.position - transform.position;


            m_CharController.enabled = false;
            CharacterTransform.DOBlendableMoveBy(new Vector3(0,difPos.y,0), 1f);
            CharacterTransform.DOBlendableMoveBy(new Vector3(difPos.x, 0, difPos.z), climbTime);

          
            yield return new WaitForSeconds(climbTime);
            m_CharController.enabled = true;
            startClimbEnd = false;
            yield return null;
        }

        private IEnumerator ReachPointTop()
        {
            startClimbAnimationTop = false;
            Vector3 difPos = climbAnchorTop.position - transform.position;
            float climbTime = 0.5f;
            Vector3 top = climbAnchorTop.parent.position - climbAnchorTop.position;
            top.y = 0;
            top = top.normalized;

            StartCoroutine(RotateToward(top));

            m_CharController.enabled = false;
            CharacterTransform.DOBlendableMoveBy(new Vector3(0, difPos.y, 0), 1f);
            CharacterTransform.DOBlendableMoveBy(new Vector3(difPos.x, 0, difPos.z), climbTime);
            yield return new WaitForSeconds(climbTime);
            climbingTop = false;
            m_CharController.enabled = true;
            yield return null;
        }


        private IEnumerator ReachPointBottom()
        {
            float climbTime = 0.5f;
            Vector3 bot = climbAnchorBottom.parent.position - climbAnchorBottom.position;
            bot.y = 0;
            bot = bot.normalized;

            yield return StartCoroutine(RotateToward(bot));

            m_CharController.enabled = false;

            CharacterTransform.DOMove(climbAnchorBottom.position, climbTime);
            yield return new WaitForSeconds(climbTime);
            climbingBottom = false;
            startClimbAnimationBottom = false;
            m_CharController.enabled = true;
            yield return null;
        }
        #endregion


        #region Pushable Coroutine

        public IEnumerator GrabPushable()
        {
            float positionTime = 0.5f;

            Vector3 dir = pushObject.transform.position - pushCollider.transform.position;
            dir.y = 0;
            dir = dir.normalized;

            yield return StartCoroutine(RotateToward(dir));



            CharacterTransform.DOMove(pushCollider.transform.GetChild(0).position, positionTime);
            yield return new WaitForSeconds(positionTime);
            pushObject.transform.SetParent(CharacterTransform);  // Set the pushable object as Child
            pushObject.GetComponent<Rigidbody>().isKinematic = false;
            isPushing = false;
            yield return null;
        }

        public IEnumerator DetachFromPushable()
        {
            pushObject.transform.parent = null;                       // Detach the pushable object from the Player
            pushObject.GetComponent<Rigidbody>().isKinematic = true;
            yield return new WaitForSeconds(0.5f);
            isExitPush = false;
            //pushObject = null;
            //pushCollider = null;
            yield return null;
        }

        #endregion

        #region Door Coroutine

        public void EndDoorInteraction()
        {
            isEndAnim = true;   
        }

        private IEnumerator DoorInteraction()
        {
            startDoorAction = false;
            float InteractTime = 0.5f;

            Vector3 dir = doorObject.transform.position - doorCollider.transform.position;
            dir.y = 0;
            dir = dir.normalized;

            yield return StartCoroutine(RotateToward(dir));

            m_CharController.enabled = false;
            CharacterTransform.DOMove(doorCollider.transform.GetChild(0).position, InteractTime);

            yield return new WaitForSeconds(InteractTime);
            if (doorObject.transform.GetComponentInChildren<Doors>().hasKey)
            {
                StartCoroutine(RotateDoor(isDoorOpen, doorObject));
            }
            else
            {
                m_CharController.enabled = true;
                isDoorRotate = true;
            }
            yield return null;
        }

        IEnumerator RotateDoor(bool isDoorOpen, GameObject doorObject)
        {
            float openDoorTime = 1f;

            if (!isDoorOpen)
            {
               doorObject.transform.Find("Hinge").DOLocalRotate(new Vector3(0, -90, 0), openDoorTime);
            }
            else
            {
                doorObject.transform.Find("Hinge").DOLocalRotate(new Vector3(0, 0, 0), openDoorTime);
            }
            yield return new WaitForSeconds(openDoorTime);
            m_CharController.enabled = true;
            isDoorRotate = true;
            yield return null;
        }

        #endregion

        #region Item Collection Coroutine

        private IEnumerator ItemCollection()
        {
            float collectTime = 2f;


            m_CharController.enabled = false;

            yield return new WaitForSeconds(collectTime);
            startItemAnimation = false;
            m_CharController.enabled = true;
            yield return null;
        }

        #endregion

        #region Rotate Toward Target Coroutine

        IEnumerator RotateToward(Vector3 finalDirection)
        {
            float rotatingSpeed = 10f;
            while ((CharacterTransform.forward - finalDirection).sqrMagnitude > 0.01f)
            {
                float step = rotatingSpeed * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(CharacterTransform.forward, finalDirection, step, 0.0f);
                CharacterTransform.rotation = Quaternion.LookRotation(newDir);
                yield return null;
            }
        }

        #endregion

        private void OnAnimatorIK(int layerIndex)
        {
            
            if (useEndClimbIk)
            {
                ikWeight -= Time.deltaTime;
             
                m_Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight);
                m_Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight);

                m_Animator.SetIKPosition(AvatarIKGoal.RightHand, climbCollider.transform.parent.GetChild(5).position);
                m_Animator.SetIKPosition(AvatarIKGoal.LeftHand, climbCollider.transform.parent.GetChild(6).position);
            }
        }

        void Update()
        {
            UpdateSoundRange();

            if (startClimbAnimationEnd)
            {
                StartCoroutine(ReachPointEnd());
            }

            if (startClimbAnimationTop)
            {
                StartCoroutine(ReachPointTop());
            }

            if (startClimbAnimationBottom)
            {
                StartCoroutine(ReachPointBottom());
            }

            if (isPushing)
            {
                StartCoroutine(GrabPushable());
            }

            if (isExitPush)
            {
                StartCoroutine(DetachFromPushable());
            }

            if (startDoorAction)
            {
                StartCoroutine(DoorInteraction());
            }

            if (startItemAnimation)
            {
                StartCoroutine(ItemCollection());
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, walkStatusRange);
        }

    }
}
