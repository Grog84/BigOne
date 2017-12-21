using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerceptionBar : MonoBehaviour {

    private float fillingPerc;
    private Image m_Image;
    private Camera cameraToLookAt;
    private Animator m_UIAnimator;

    private void Awake()
    {
        m_Image = GetComponentInChildren<Image>();
        GameObject cameraObj = GameObject.FindWithTag("MainCamera");
        cameraToLookAt = cameraObj.GetComponent<Camera>();
        //m_Image.fillAmount = 0f;
        m_UIAnimator = GetComponentInChildren<Animator>();
        m_UIAnimator.speed = 0;
    }

    // Update is called once per frame
    void Update () {

        // rotate the canvas in order to face the camera
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);

        UpdateFillingPerc();
    }

    private void UpdateFillingPerc()
    {
        //m_Image.fillAmount = fillingPerc;
        m_UIAnimator.PlayTime(fillingPerc);
    }

    public void SetFillingPerc(float fill)
    {
        fillingPerc = fill/100.0f;
        fillingPerc = Mathf.Clamp(fillingPerc,0, 0.99f);
    }
}
