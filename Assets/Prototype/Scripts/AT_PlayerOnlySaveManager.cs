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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            Debug.Log("Saved checkpoint at x: " + collision.transform.position.x + " y: " + collision.transform.position.y + " z: " + collision.transform.position.z);
            SaveData();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            Debug.Log("Walked throw a checkpoint at" + other.transform.position.x + " y: " + other.transform.position.y + " z: " + other.transform.position.z);
            SaveData();
        }

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
