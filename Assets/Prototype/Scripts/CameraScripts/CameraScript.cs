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

    public Renderer boyJoints;
    public Renderer boySkin;

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

        


    }

    private void Update()
    {
        if (firstPersonCameraScript.FPSbyTrigger == false && thirdPersonCameraScript.distance < minCamDistance) 
        {
            firstPersonVirtualCamera.m_Priority = 100;
        }
        else if (firstPersonCameraScript.FPSbyTrigger == false && thirdPersonCameraScript.distance > minCamDistance)
        {
            firstPersonVirtualCamera.m_Priority = 0;
        }

        if (firstPersonVirtualCamera.m_Priority == 100)
        {
            SetMaterialTrasparent(boyJoints);
            SetMaterialTrasparent(boySkin);

        }
        else if (firstPersonVirtualCamera.m_Priority != 100)
        {
            SetMaterialOpaque(boyJoints);
            SetMaterialOpaque(boySkin);
        }

    }

    void SetMaterialTrasparent(Renderer mat)
    {
        mat.material.DOFade(0, 0.5f);

        mat.material.SetFloat("_Mode", 2);
        mat.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.material.SetInt("_ZWrite", 0);
        mat.material.DisableKeyword("_ALPHATEST_ON");
        mat.material.EnableKeyword("_ALPHABLEND_ON");
        mat.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.material.renderQueue = 3000;


    }

    void SetMaterialOpaque(Renderer mat)
    {
        mat.material.DOFade(255, 0.5f);

        mat.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mat.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        mat.material.SetInt("_ZWrite", 1);
        mat.material.DisableKeyword("_ALPHATEST_ON");
        mat.material.DisableKeyword("_ALPHABLEND_ON");
        mat.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.material.renderQueue = -1;

    }

}
    




