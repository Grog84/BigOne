using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;


public class CameraScript : MonoBehaviour
{
    private GameObject firstPersonCamera;
    private GameObject thirdPersonCamera;
    private CinemachineVirtualCamera firstPersonVirtualCamera;
    private CinemachineVirtualCamera thirdPersonVirtualCamera;
    private FirstPersonCameraScript firstPersonCameraScript;
    private ThirdPersonCameraScript thirdPersonCameraScript;

    private Renderer boyJoints;
    private Renderer boySkin;
    private GameObject BJoints;
    private GameObject BSkin;

    private Renderer MotherJoints;
    private Renderer MotherSkin;
    private GameObject MJoints;
    private GameObject MSkin;


    [SerializeField]
    protected LayerMask layerIgnored = ~(1 << 8);

    //variables initialized at start 
    protected Transform motherLookAt;
    protected Transform boyLookAt;
    protected Transform motherLookAtByTag;
    protected Transform boyLookAtByTag;
    protected Transform lookAt;                    // object that the camera is looking at
    protected Transform camTransform;

    public float minCamDistance = 1f;
    
    //camera variables for the position 
    protected float nearClipPlaneDistance = 0.1f;
    protected float distance = 2.5f;
    public float maxDistance = 2.5f;
    // position of the camera assigned in the camera movement
    protected float currentX = 0.0f;
    protected float currentY = 0.0f;
    protected Vector3 dir = new Vector3();
    protected Quaternion rotation = new Quaternion();


    public virtual void SwitchLookAt(){}

    protected void Awake()
    {
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
        if(thirdPersonVirtualCamera.m_Priority > firstPersonVirtualCamera.m_Priority)
        {
            GMController.instance.activeCamera = (CameraActive)0;
        }
        else if( firstPersonVirtualCamera.m_Priority > thirdPersonVirtualCamera.m_Priority)
        {
            GMController.instance.activeCamera = (CameraActive)1;
        }

        if (firstPersonCameraScript.FPSbyTrigger == false && thirdPersonCameraScript.distance < minCamDistance) 
        {
            firstPersonVirtualCamera.m_Priority = 100;
        }
        else if (firstPersonCameraScript.FPSbyTrigger == false && thirdPersonCameraScript.distance > minCamDistance)
        {
            firstPersonVirtualCamera.m_Priority = 0;
        }

        if (firstPersonVirtualCamera.m_Priority == 100 && (int)GMController.instance.isCharacterPlaying == 0)
        {
            StartCoroutine(SetMaterialTrasparent(boyJoints));
            StartCoroutine(SetMaterialTrasparent(boySkin));

        }
        else if (firstPersonVirtualCamera.m_Priority != 100 && (int)GMController.instance.isCharacterPlaying == 0)
        {
            StartCoroutine(SetMaterialOpaque(boyJoints));
            StartCoroutine(SetMaterialOpaque(boySkin));
        }

        if (firstPersonVirtualCamera.m_Priority == 100 && (int)GMController.instance.isCharacterPlaying == 1)
        {
            StartCoroutine(SetMaterialTrasparent(MotherJoints));
            StartCoroutine(SetMaterialTrasparent(MotherSkin));

        }
        else if (firstPersonVirtualCamera.m_Priority != 100 && (int)GMController.instance.isCharacterPlaying == 1)
        {
            StartCoroutine(SetMaterialOpaque(MotherJoints));
            StartCoroutine(SetMaterialOpaque(MotherSkin));
        }


    }

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
        mat.material.DOFade(0, 0.5f);
        yield return null;
    }

    IEnumerator SetMaterialOpaque(Renderer mat)
    {
        mat.material.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.1f);

        mat.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mat.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        mat.material.SetInt("_ZWrite", 1);
        mat.material.DisableKeyword("_ALPHATEST_ON");
        mat.material.DisableKeyword("_ALPHABLEND_ON");
        mat.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.material.renderQueue = -1;
        yield return null;
    }

}