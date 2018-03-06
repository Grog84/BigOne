using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using RootMotion.FinalIK;

namespace Character
{
    public enum SoundStatus { WALK, CROUCH, RUN}
    public class _CharacterController : MonoBehaviour
    {
        [HideInInspector] public bool hasInteractedWithNPC = false;
        [HideInInspector] public bool isCarrying = false;
        [HideInInspector] public int currentConsegnaOggetto;
        [HideInInspector] public bool firstCrouch = false;             // used to fill the bounds crouch array 1 time only
        [HideInInspector] public bool canStand = true;
        [HideInInspector] public bool Crouch = false;
        [HideInInspector] public bool isInDanger = false;
        [HideInInspector] public float m_MoveSpeedMultiplier;
        [HideInInspector] public float m_TurnAmount;                   // Unutilized for the moment
        [HideInInspector] public float m_ForwardAmount;
        [HideInInspector] public float ray_length;
        [HideInInspector] public float animSpeed;
        //
        // BALANCE VARIABLES
        [HideInInspector] public bool isInBalanceArea;
        [HideInInspector] public bool startBalanceBoard;
        [HideInInspector] public bool startBalanceLedge;
        [HideInInspector] public bool isInJointArea;
        [HideInInspector] public bool isLedgeLimit;
        [HideInInspector] public bool ledgeForwardActive = true;
        [HideInInspector] public bool ledgeBackwardActive = true;
        [HideInInspector] public bool isBalanceCRDone = true;
        [HideInInspector] public float ledgeCRTime;
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
        [HideInInspector] public bool isClimbCRDone = true;
        [HideInInspector] public bool isBottomClimbCRDone = true;
        //
        // PUSH VARIABLES
        [HideInInspector] public bool isInPushArea;                    // The player is in the trigger area for Pushing
        [HideInInspector] public bool isPushDirectionRight;            // The player is facing the pushable object
        [HideInInspector] public bool isPushLimit;                      // Detect push limits like obstacles
        [HideInInspector] public bool isPushing;                       // Define the start push actions
        [HideInInspector] public bool isExitPush;                      // Indicates if the DetachFormPushable coroutine is finished
        //
        // DOORS VARIABLES
        [HideInInspector] public bool isInDoorArea;                    // Detect if the player is in the Door trigger area
        [HideInInspector] public bool isDoorDirectionRight;            // Detect if the player is looking toward the door
        [HideInInspector] public bool startDoorAction;                 // Starts the DoorInteraction courutine
        [HideInInspector] public bool isEndDoorAction;                 // Indicates if the DoorInteraction coroutine is finished
        [HideInInspector] public bool isDoorOpen;                      // Indicates if the door has to be opended or closed in the RotateDoor coroutine
        [HideInInspector] public bool isDoorRotate;                    // Indicates if the RotateDoor coroutine is finished
        [HideInInspector] public bool isEndAnim = false;               // Indicates if the player playing the door animation
        //
        // ITEMS VARIABLES
        [HideInInspector] public bool startItemAnimation;              // Starts the item collection courutine
        [HideInInspector] public bool isInItemArea;                     // Detect if the player is in the key object interactable area
        [HideInInspector] public bool isItemCREnd = true;
        //
        //SOUND EMISSION VARIABLES
        [HideInInspector] public bool canStep = true;
        [HideInInspector] public SoundStatus m_SoundStatus;
        [HideInInspector] public float m_Soundrange_sq;
        public float m_SoundStatusRange = 1f;
        [HideInInspector] public float floorNoiseMultiplier;
        [HideInInspector] public FootstepsEmitter footStepsEmitter;

        [HideInInspector] public float charDepth;
        [HideInInspector] public float charSize;
        // COMPONENTS REFERENCES
        [HideInInspector] public Animator m_Animator;
        [HideInInspector] public Transform m_Camera;                   // A reference to the main camera in the scenes transform
        [HideInInspector] public Transform CharacterTransform;         // A reference to the character assigned to the state controller transform
        [HideInInspector] public Rigidbody m_Rigidbody;                // A reference to the rigidbody
        [HideInInspector] public CharacterController m_CharController; // A reference to the Character controller component
        [HideInInspector] public LookAtIK playerSight;
        [HideInInspector] public GrounderFBBIK playerGrounderIK;
        public PlayFMODLoop playLoop;

        // COLLIDERS REFERENCES  
        [HideInInspector] public GameObject npcSightCollider;

        [HideInInspector] public GameObject climbCollider;
        [HideInInspector] public Transform climbAnchorTop;
        [HideInInspector] public Transform climbAnchorBottom;
        [HideInInspector] public Transform endClimbAnchor;

        [HideInInspector] public GameObject doorObject;
        [HideInInspector] public GameObject doorCollider;
        [HideInInspector] public GameObject doorBody;

        [HideInInspector] public GameObject ItemCollider;

        [HideInInspector] public GameObject pushHit = null;            // Used for icons 
        [HideInInspector] public GameObject pushObject;
        [HideInInspector] public GameObject pushCollider = null;

        [HideInInspector] public GameObject balanceCollider;
        [HideInInspector] public GameObject forwardBalance;
        [HideInInspector] public GameObject balanceJoint;
        [HideInInspector] public GameObject boardOppositePoint;
        //
        [HideInInspector] public bool isDefeated = false;
        // Alpha management for Icons
        [HideInInspector] public Color alphaZero;
        [HideInInspector] public Color alphaMax;
        [HideInInspector] public Transform playerIcon;
        //LOOK AT
        [HideInInspector] public float headClamp;
        [HideInInspector] public bool canLookAt = false;
        [HideInInspector] public bool dontLookAt = false;
        [HideInInspector] public bool isCanLookAtDone = true;
        [HideInInspector] public bool isDontLookAtDone = true;
        [HideInInspector] public GameObject cameraPoint;
        [HideInInspector] public bool isDefaultLookAt = false;
      
        public Transform playerGaze;
        public GameObject LookAtItems;
        public Transform playerHead;
        public Transform playerCanvas;
        public Sprite cantCancelClimbIcon;
        public Sprite stopPush;
        public Sprite stopClimb;
        public CharacterStats m_CharStats;
        public LayerMask m_WalkNoiseLayerMask;
        public List<GameObject> Keychain;                               // List of all the key items collected by the player
        public Vector3[] BoundRaycasts = new Vector3[5];              

        private bool oneStepCoroutineController = true;                 // used to make sure only one step coroutine is runnin at a given time


        private void Awake()
        {
            playLoop = GetComponent<PlayFMODLoop>();
            playerGrounderIK = GetComponent<GrounderFBBIK>();
            CharacterTransform = GetComponent<Transform>();          // A reference to the character assigned to the state controller transform
            m_Animator = GetComponent<Animator>();
            m_CharController = GetComponent<CharacterController>();
            GameObject m_CameraObj = GameObject.FindGameObjectsWithTag("MainCamera")[0];
            m_Camera = m_CameraObj.transform;
            footStepsEmitter = GetComponent<FootstepsEmitter>();
            alphaMax = new Color(100, 100, 100, 255);
            alphaZero = new Color(0, 0, 0, 0);
            playerIcon = playerCanvas.GetChild(0);
            playerSight = GetComponent<LookAtIK>();
            headClamp = playerSight.solver.headWeight;
            cameraPoint = m_Camera.Find("LookAtTarget").gameObject;
        }

        // Use this for initialization
        void Start()
        {
            isInClimbArea = false;
            isInPushArea = false;
            ray_length = m_CharController.bounds.size.y / 2.0f + 0.1f;
            playerSight.solver.target = cameraPoint.transform;
        }

        #region Raycast Check

        void ActivateDoors()
        {
            RaycastHit hit;
            Debug.DrawRay(playerHead.position, playerHead.forward);
            if (isInDoorArea)
            {
                if (Physics.Raycast(playerHead.position, playerHead.forward, out hit, m_CharStats.m_DistanceFromDoor))
                {
                    
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Doors") &&
                        hit.transform == doorCollider.transform.parent.FindDeepChild("DoorBody"))
                    {
                        isDoorDirectionRight = true;
                        doorBody = hit.transform.gameObject;
                    }
                    else
                    {
                        isDoorDirectionRight = false;
                        doorBody = null;
                    }
                }
                else
                {
                    isDoorDirectionRight = false;
                    doorBody = null;
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

                    
                if (Physics.Raycast(CharacterTransform.position + Vector3.up * m_CharController.bounds.size.y / 2.0f, CharacterTransform.forward, out hit, m_CharStats.m_DistanceFromPushableObject))
                {
            


                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Pushable") &&
                        hit.transform == pushCollider.transform.parent)
                    {
                        isPushDirectionRight = true;
                        pushHit = hit.transform.gameObject;
                    }
                    else
                    {
                        isPushDirectionRight = false;
                        pushHit = null;
                    }
                }
                else
                {
                    isPushDirectionRight = false;
                    pushHit = null;
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
                climbCollider.transform.parent.GetComponent<ClimbableIconsActivation>().ShowIcon(this.gameObject);
            }

            if (other.tag == "Ladder_Top")
            {           
                climbingTop = true;
                ActivateClimbingChoice();
                climbCollider.transform.parent.GetComponent<ClimbableIconsActivation>().ShowIcon(this.gameObject);
            }

            if (other.tag == "PushTrigger" && Vector3.Angle(CharacterTransform.forward, other.transform.forward) < 45)
            {
                pushCollider = other.gameObject;
                isInPushArea = true;
                ActivatePushingChoice();
                pushCollider.transform.parent.GetComponent<PushableIconsActivation>().ShowIcon(this.gameObject);
            }
            else if (other.tag == "PushTrigger" && Vector3.Angle(CharacterTransform.forward, other.transform.forward) > 45)
            {
                ActivatePushingChoice();
            }

            if (other.tag == "UnlockedDoor" || other.tag == "LockedDoor")
            {
                doorCollider = other.gameObject;
                ActivateDoors();
                doorCollider.transform.parent.GetComponent<DoorIconsActivation>().ShowIcon(this.gameObject);
                
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                  ItemCollider = other.gameObject;
                  isInItemArea = true;
                  ItemCollider.GetComponent<CollectablesIconsActivation>().ShowIcon(this.gameObject);
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Balance"))
            {
                balanceCollider = other.gameObject;
                isInBalanceArea = true;

                if (other.tag == "Joint")
                {
                    balanceJoint = other.gameObject;
                    isInJointArea = true;
                    isLedgeLimit = true;
                }
            }

            if (other.tag == "NpcSight")
            {
                npcSightCollider = other.gameObject;
                other.transform.parent.GetComponent<NpcQuestIcons>().ShowIcon(this.gameObject);
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

                if (other.tag == "LockedDoor")
                {
                    for (int i = 0; i < Keychain.Count; i++)
                    {
                        if(Keychain[i].GetComponent<Keys>().ItemID == other.transform.parent.GetChild(0).GetChild(0).GetComponent<Doors>().doorID)
                        {
                            HideHUDIcons(Keychain[i].gameObject.GetComponent<Keys>().icon);
                            other.transform.parent.GetChild(0).GetChild(0).tag = "UnlockedDoor";
                            other.transform.parent.GetChild(0).GetChild(0).GetComponent<Doors>().hasKey = true;
                        }
                    }
                }
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                ItemCollider = other.gameObject;
                isInItemArea = true;
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Balance"))
            {

                if (other.tag == "Board")
                {
                    balanceCollider = other.gameObject;
                    isInBalanceArea = true;
                }
                if (other.tag == "Ledge")
                {
                    balanceCollider = other.gameObject;
                    isInBalanceArea = true;
                }            

                if (other.tag == "Joint")
                {
                    balanceJoint = other.gameObject;
                    isInJointArea = true;
                    isLedgeLimit = true;
                }
            }

            if (other.tag == "NpcSight")
            {
                npcSightCollider = other.gameObject;
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
                climbCollider.transform.parent.GetComponent<ClimbableIconsActivation>().HideIcons(climbCollider.transform.parent.GetComponent<ClimbableIconsActivation>().topIcons);
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
                doorCollider.transform.parent.GetComponent<DoorIconsActivation>().HideIcons();
                doorCollider = null;
                isInDoorArea = false;
                isDoorDirectionRight = false;
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                ItemCollider.GetComponent<CollectablesIconsActivation>().HideIcons();
                ItemCollider = null;
                isInItemArea = false;
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Balance"))
            {
                if(other.tag == "Board")
                {  
                    balanceCollider = null;
                    isInBalanceArea = false;
                }
                if (other.tag == "Ledge")
                {
                    balanceCollider = null;
                    isInBalanceArea = false;
                }

                if (other.tag == "Joint")
                {
                    //balanceJoint = null;
                    isInJointArea = false;
                    isLedgeLimit = false;
                }
            }
            if (other.tag == "NpcSight")
            {
                other.transform.parent.GetComponent<NpcQuestIcons>().HideIcons();
               // npcSightCollider = null;
            }

        }

        #endregion

        public void UpdateSoundStatus(SoundStatus soundStatus)
        {
            m_SoundStatus = soundStatus;
            switch (m_SoundStatus)
            {
                case SoundStatus.WALK:
                    m_SoundStatusRange = m_CharStats.m_WalkSoundrange;
                    break;
                case SoundStatus.CROUCH:
                    m_SoundStatusRange = m_CharStats.m_CrouchSoundrange;
                    break;
                case SoundStatus.RUN:
                    m_SoundStatusRange = m_CharStats.m_RunSoundrange;
                    break;
                default:
                    break;
            }
        }

        private void UpdateSoundRange()  // This could be improved by updating only the data necessary
        {   
            m_Soundrange_sq = m_SoundStatusRange * m_SoundStatusRange * m_ForwardAmount;
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
            Debug.Log("Fine CLimb");
            useEndClimbIk = true;
            startClimbAnimationEnd = false;
            float climbTime = 1.3f;
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
            float climbTime = 0.2f;
            Vector3 top = climbAnchorTop.parent.position - climbAnchorTop.position;
            top.y = 0;
            top = top.normalized;

            StartCoroutine(RotateToward(top));

            m_CharController.enabled = false;
            CharacterTransform.DOBlendableMoveBy(new Vector3(0, difPos.y, 0), 0.5f);
            CharacterTransform.DOBlendableMoveBy(new Vector3(difPos.x, 0, difPos.z), climbTime);
            yield return new WaitForSeconds(climbTime);
            m_Animator.SetBool("isClimbing", true);
            yield return new WaitForSeconds(0.5f);
            climbingTop = false;
            isClimbCRDone = true;
            m_CharController.enabled = true;
            yield return null;
        }


        private IEnumerator ReachPointBottom()
        {
            startClimbAnimationBottom = false;
            float climbTime = 0.5f;
            Vector3 bot = climbAnchorBottom.parent.position - climbAnchorBottom.position;
            bot.y = 0;
            bot = bot.normalized;

            yield return StartCoroutine(RotateToward(bot));

            m_CharController.enabled = false;

            CharacterTransform.DOMove(climbAnchorBottom.position, climbTime);
            yield return new WaitForSeconds(climbTime);
            m_Animator.SetBool("isClimbing", true);
            yield return new WaitForSeconds(0.5f);
            climbingBottom = false;
            m_CharController.enabled = true;
            isBottomClimbCRDone = true;
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

            Vector3 dir = doorBody.transform.position - doorCollider.transform.position;
            dir.y = 0;
            dir = dir.normalized;

            yield return StartCoroutine(RotateToward(dir));

            m_CharController.enabled = false;
            doorCollider.transform.parent.GetComponent<DoorIconsActivation>().HideIcons();
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
            startItemAnimation = false;
            float collectTime = 0.3f;


            m_CharController.enabled = false;

            yield return new WaitForSeconds(collectTime);
            m_CharController.enabled = true;
            isItemCREnd = true;
            yield return null;
        }

        #endregion

        #region Balance

        IEnumerator OnBalanceBoard()
        {
            startBalanceBoard = false;
            float positionTime = 0.3f;

            Vector3 dir = boardOppositePoint.transform.position - forwardBalance.transform.position;
            dir.y = 0;
            dir = dir.normalized;

            yield return StartCoroutine(RotateToward(dir));

            CharacterTransform.DOMove(forwardBalance.transform.position, positionTime);
            yield return new WaitForSeconds(positionTime);
            m_Animator.applyRootMotion = true;
            isBalanceCRDone = true;
        }

        IEnumerator OnBalanceLedge(float crTime)
        {

            startBalanceLedge = false;
            Vector3 dir = forwardBalance.transform.GetChild(0).position - forwardBalance.transform.position;
            dir.y = 0;
            dir = dir.normalized;

            yield return StartCoroutine(RotateToward(dir));

            CharacterTransform.DOMove(forwardBalance.transform.position, crTime);
            yield return new WaitForSeconds(crTime);
            isBalanceCRDone = true;
          
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
            CharacterTransform.rotation = Quaternion.LookRotation(finalDirection);
        }

        #endregion

        #region Icons

        public void IconPriority(Transform icons, int degrees)
        {
            if (Vector3.Angle(m_Camera.forward, icons.forward) > degrees )
            {
                m_Camera.GetChild(0).gameObject.SetActive(false);

            }
            else
            {
                m_Camera.GetChild(0).gameObject.SetActive(true);
            }
        }

        public void ShowStopPushIcon()
        {
            playerIcon.GetChild(0).GetComponent<Image>().sprite = stopPush;
            playerIcon.GetChild(0).GetComponent<Image>().color = alphaMax;
        }

        public void ShowStopClimbIcon()
        {
            playerIcon.GetChild(0).GetComponent<Image>().sprite = stopClimb;
            playerIcon.GetChild(0).GetComponent<Image>().color = alphaMax;
        }

        public void ShowDisabledCancelIcon()
        {
            playerIcon.GetChild(0).GetComponent<Image>().sprite = cantCancelClimbIcon;
            playerIcon.GetChild(0).GetComponent<Image>().color = alphaMax;
        }

        public void HideIcon()
        {
            playerIcon.GetChild(0).GetComponent<Image>().color = alphaZero;
            playerIcon.GetChild(0).GetComponent<Image>().sprite = null;
        }

        public void RotateCanvas()
        {
            playerIcon.DOLookAt(m_Camera.transform.position, 0.1f);
        }

        public void HideHUDIcons(Transform icon)
        {
            icon.GetComponent<Image>().color = alphaZero;
            icon.GetComponent<Image>().sprite = null;
        }

        #endregion

        #region LookAt

        IEnumerator DontLookAt()
        {
            dontLookAt = false;
            isDontLookAtDone = false;

            Debug.Log(playerSight.solver.headWeight > 0);
            while (playerSight.solver.headWeight > 0)
            {
                playerSight.solver.headWeight -= Time.deltaTime;
            }

            yield return isDontLookAtDone = true;
            
        }

        IEnumerator CanLookAt()
        {
            canLookAt = false;
            isCanLookAtDone = false;

            while (playerSight.solver.headWeight < headClamp)
            {
                playerSight.solver.headWeight += Time.deltaTime;
            }
          
             yield return isCanLookAtDone = true;
            
        }

        IEnumerator ResetLookAtTarget()
        {
            isDefaultLookAt = false;
            playerSight.solver.target = cameraPoint.transform;
            yield return null;
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

            if (startBalanceBoard)
            {
                StartCoroutine(OnBalanceBoard());
            }

            if(startBalanceLedge)
            {
                StartCoroutine(OnBalanceLedge(ledgeCRTime));
            }

            if(canLookAt)
            {
                StartCoroutine(CanLookAt());
            }

            if (dontLookAt)
            {
                StartCoroutine(DontLookAt());
            }

            if (isDefaultLookAt)
            {
                StartCoroutine(ResetLookAtTarget());
            }
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.DrawWireSphere(transform.position, m_SoundStatusRange);
        //}

    }
}
