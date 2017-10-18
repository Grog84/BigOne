using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AT_PlayerOnlySaveManager : AT_ProvaSalvataggio
{
    [Header("Sezione Fade Out",order =0)]
    [SerializeField]private Image blackScreen;
    [Range(0.1f,1f)]
    [SerializeField]private float fadeOutTime = 0.5f;
    
    private void Awake()
    {
       
        FadeFromBlack();
    }
    // Use this for initialization
    void Start()
    {
 
    }
    // Update is called once per frame
    private void Update()
    {
      
    }


    private void LoadData()
    {
       
        FadeFromBlack();


    }

    #region 3rdPartyScript
    void FadeFromBlack()
    {
       blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(1.0f);
         blackScreen.CrossFadeAlpha(0.0f, fadeOutTime, false);
    }
    #endregion
}
