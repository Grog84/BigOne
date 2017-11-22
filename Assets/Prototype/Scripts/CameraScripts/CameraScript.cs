using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;


public class CameraScript : MonoBehaviour
{
    //references to other virtual cameras
    private GameObject firstPersonCamera;
    private GameObject thirdPersonCamera;
    private CinemachineVirtualCamera firstPersonVirtualCamera;
    private CinemachineVirtualCamera thirdPersonVirtualCamera;
    private FirstPersonCameraScript firstPersonCameraScript;
    private ThirdPersonCameraScript thirdPersonCameraScript;

    //check wich character is in trigger
    public bool motherInTrigger = false;
    public bool boyInTrigger = false;

    // objects of the characters that the camera fades when too close to them
    private Renderer boyJoints;
    private Renderer boySkin;
    private GameObject BJoints;
    private GameObject BSkin;

    private Renderer MotherJoints;
    private Renderer MotherSkin;
    private GameObject MJoints;
    private GameObject MSkin;

    //Array of cameras used to reset the priority to default on swtich
    protected CinemachineVirtualCamera[] camerasInScene;
    [SerializeField]
    protected LayerMask layerIgnored = ~(1 << 8);

    //check if the camera is in a different state from the normal gameplay Camera
    public bool activatedByTrigger = false;
    //variables initialized at start 
    protected Transform motherLookAt;
    protected Transform boyLookAt;
    protected Transform motherLookAtByTag;
    protected Transform boyLookAtByTag;
    protected Transform lookAt;                    // object that the camera is looking at
    protected Transform camTransform;

    //minimum distance of the camera to the character before switching to fps
    public float minCamDistance = 1f;

    //camera variables for the position 
    protected float nearClipPlaneDistance = 0.1f;
    protected float distance = 2.5f;
    //maximum distance from the character
    public float maxDistance = 2.5f;
    // position of the camera assigned in the camera movement
    protected float currentX = 0.0f;
    protected float currentY = 0.0f;
    protected Vector3 dir = new Vector3();
    protected Quaternion rotation = new Quaternion();

    //method used for switching character
    public virtual void SwitchLookAt() { }

    protected void Awake()
    {
        camerasInScene = FindObjectsOfType<CinemachineVirtualCamera>();
        motherLookAt = GameObject.Find("Mother").GetComponent<Transform>();
        boyLookAt = GameObject.Find("Boy").GetComponent<Transform>();

        motherLookAtByTag = motherLookAt.FindDeepChildByTag("LookAtCamera");
        boyLookAtByTag = boyLookAt.FindDeepChildByTag("LookAtCamera");
    }

    private void Start()
    {
        firstPersonCamera = GameObject.Find("FirstPersonCamera");
        firstPersonVirtualCamera = firstPersonCamera.GetComponent<CinemachineVirtualCamera>();
        firstPersonCameraScript = firstPersonCamera.GetComponent<FirstPersonCameraScript>();
        thirdPersonCamera = GameObject.Find("ThirdPersonCamera");
        thirdPersonVirtualCamera = thirdPersonCamera.GetComponent<CinemachineVirtualCamera>();
        thirdPersonCameraScript = thirdPersonCamera.GetComponent<ThirdPersonCameraScript>();
        BJoints = GameObject.Find("Alpha_Joints");
        boyJoints = BJoints.GetComponent<Renderer>();
        BSkin = GameObject.Find("Alpha_Surface");
        boySkin = BSkin.GetComponent<Renderer>();
        MJoints = GameObject.Find("Beta_Joints");
        MotherJoints = MJoints.GetComponent<Renderer>();
        MSkin = GameObject.Find("Beta_Surface");
        MotherSkin = MSkin.GetComponent<Renderer>();

    }

    private void Update()
    {
        //check which camera is active
        if (thirdPersonVirtualCamera.m_Priority > firstPersonVirtualCamera.m_Priority)
        {
            GMController.instance.activeCamera = (CameraActive)0;
        }
        else if (firstPersonVirtualCamera.m_Priority > thirdPersonVirtualCamera.m_Priority)
        {
            GMController.instance.activeCamera = (CameraActive)1;
        }

        #region Fade
        //trigger the switch to fps or tps using the distance of the camera from the player
        if (activatedByTrigger == false && thirdPersonCameraScript.distance < minCamDistance)
        {
            firstPersonVirtualCamera.m_Priority = 100;
        }
        else if (activatedByTrigger == false && thirdPersonCameraScript.distance > minCamDistance)
        {
            firstPersonVirtualCamera.m_Priority = 0;
        }

        // fade of the boy when camera too close
        if (firstPersonVirtualCamera.m_Priority == 100 && ((int)GMController.instance.isCharacterPlaying == 0 && boyInTrigger == true) 
            || firstPersonVirtualCamera.m_Priority == 100 && activatedByTrigger == false && thirdPersonCameraScript.distance < minCamDistance && (int)GMController.instance.isCharacterPlaying == 0)

        {
            StartCoroutine(SetMaterialTrasparent(boyJoints));
            StartCoroutine(SetMaterialTrasparent(boySkin));

        }
        else if (firstPersonVirtualCamera.m_Priority != 100 || (int)GMController.instance.isCharacterPlaying != 0
            || firstPersonVirtualCamera.m_Priority != 100 && activatedByTrigger == false && thirdPersonCameraScript.distance > minCamDistance )
        {
            StartCoroutine(SetMaterialOpaque(boyJoints));
            StartCoroutine(SetMaterialOpaque(boySkin));
        }

        //fade of the mother if camera too close
        if (firstPersonVirtualCamera.m_Priority == 100 && ((int)GMController.instance.isCharacterPlaying == 1 && motherInTrigger == true)
            || firstPersonVirtualCamera.m_Priority == 100 && activatedByTrigger == false && thirdPersonCameraScript.distance < minCamDistance && (int)GMController.instance.isCharacterPlaying == 1)
        {
            StartCoroutine(SetMaterialTrasparent(MotherJoints));
            StartCoroutine(SetMaterialTrasparent(MotherSkin));

        }
        else if (firstPersonVirtualCamera.m_Priority != 100 || (int)GMController.instance.isCharacterPlaying != 1
             || firstPersonVirtualCamera.m_Priority != 100 && activatedByTrigger == false && thirdPersonCameraScript.distance > minCamDistance )
        {
            StartCoroutine(SetMaterialOpaque(MotherJoints));
            StartCoroutine(SetMaterialOpaque(MotherSkin));
        }
#endregion





    }


    //method used to start the fade of the material setting it to transparent and manipulating the alpha
    IEnumerator SetMaterialTrasparent(Renderer mat)
    {
        mat.material.SetFloat("_Mode", 2);
        mat.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.material.SetInt("_ZWrite", 0);
        mat.material.DisableKeyword("_ALPHATEST_ON");
        mat.material.EnableKeyword("_ALPHABLEND_ON");
        mat.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.material.renderQueue = 3000;
        mat.material.DOFade(0, 0.3f);
        yield return null;
    }

    //method used to revert the fade of the material setting it to opaque and manipulating the alpha
    IEnumerator SetMaterialOpaque(Renderer mat)
    {
        mat.material.DOFade(1, 0.5f);
        yield return new WaitForSecondsRealtime(0.1f);

        mat.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mat.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        mat.material.SetInt("_ZWrite", 1);
        mat.material.DisableKeyword("_ALPHATEST_ON");
        mat.material.DisableKeyword("_ALPHABLEND_ON");
        mat.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.material.renderQueue = -1;
        yield return null;
    }


    protected IEnumerator ResetCameraPriority()
    {
        for (int c = 0; c < camerasInScene.Length; c++)
        {
            if(camerasInScene[c].gameObject.name != "ThirdPersonCamera")
            {
                camerasInScene[c].m_Priority = 0;
            }
        }
        yield return null;
    }

}